
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeoutLOSCS : MonoBehaviour {

	/* Fades out any objects between the player and this transform.
       The renderers shader is first changed to be an Alpha/Diffuse, then alpha is faded out to fadedOutAlpha.
       Only objects
       
       In order to catch all occluders, 5 rays are casted. occlusionRadius is the distance between them.
    */
	public LayerMask layerMask = 0;
	public Transform target ;
	public float fadeSpeed = 1.0f;
	public float occlusionRadius = 0.3f;
	public float fadedOutAlpha = 0.3f;
	
	private List<FadeoutLOSInfo> fadedOutObjects = new List<FadeoutLOSInfo>();

	
	public class FadeoutLOSInfo
	{
		public Renderer renderer ;
		public Material[] originalMaterials;
		public Material[] alphaMaterials ;
		public bool needFadeOut = true;
	}
	
	public FadeoutLOSInfo FindLosInfo (Renderer r)
	{
		foreach (FadeoutLOSInfo fade in fadedOutObjects)
		{
			if (r == fade.renderer)
				return fade;
		}
		return null;
	}
	
	public void Update()
	{
		//Debug.Log("Update");
	}
	
	public void LateUpdate () {
		//Debug.Log("LateUpdate");
		
		Vector3 from = transform.position;
		Vector3 to = target.position;
		float castDistance = Vector3.Distance(to, from);
		
		// Mark all objects as not needing fade out
		foreach (FadeoutLOSInfo fade in fadedOutObjects)
		{
			fade.needFadeOut = false;
		}
		
		Vector3[] offsets = new Vector3[]{new Vector3(0, 0, 0),
										  new Vector3(0, occlusionRadius, 0),
										  new Vector3(0, -occlusionRadius, 0),
										  new Vector3(occlusionRadius, 0, 0),
										  new Vector3(-occlusionRadius, 0, 0)};
		
		// We cast 5 rays to really make sure even occluders that are partly occluding the player are faded out
		foreach (Vector3 offset in offsets)
		{
			var relativeOffset = transform.TransformDirection(offset);
			// Find all blocking objects which we want to hide
			RaycastHit[] hits = Physics.RaycastAll(from + relativeOffset, to - from, castDistance, layerMask.value);
			foreach (RaycastHit hit in hits)
			{
				// Make sure we have a renderer
				Renderer hitRenderer = hit.collider.renderer;    
				if (hitRenderer == null || !hitRenderer.enabled)
					continue;
				
				FadeoutLOSInfo info = FindLosInfo(hitRenderer);
				
				// We are not fading this renderer already, so insert into faded objects map
				if (info == null)
				{
					info = new FadeoutLOSInfo ();
					info.originalMaterials = hitRenderer.sharedMaterials;
					info.alphaMaterials = new Material[info.originalMaterials.Length];
					info.renderer = hitRenderer;
					for (int i = 0; i < info.originalMaterials.Length; i++)
					{
						Material newMaterial = new Material (Shader.Find("Alpha/Diffuse"));
						newMaterial.mainTexture = info.originalMaterials[i].mainTexture;   
						newMaterial.color = info.originalMaterials[i].color;
						newMaterial.color = new Color(newMaterial.color.r, newMaterial.color.g, newMaterial.color.b, 1.0f);
						info.alphaMaterials[i] = newMaterial;
					}
					
					hitRenderer.sharedMaterials = info.alphaMaterials;
					fadedOutObjects.Add(info);
				}
				// Just mark the renderer as needing fade out
				else
				{
					info.needFadeOut = true;
				}
			}
		}
		
		// Now go over all renderers and do the actual fading!
		float fadeDelta = fadeSpeed * Time.deltaTime;
		for (int i = 0; i < fadedOutObjects.Count; i++)
		{
			FadeoutLOSInfo fade = fadedOutObjects[i];
			// Fade out up to minimum alpha value
			if (fade.needFadeOut)
			{
				foreach (Material alphaMaterial in fade.alphaMaterials)
				{
					float alpha = alphaMaterial.color.a;
					alpha -= fadeDelta;
					alpha = Mathf.Max(alpha, fadedOutAlpha);
					alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, alpha);
				}
			}
			// Fade back in
			else
			{
				int totallyFadedIn = 0;
				foreach (Material alphaMaterial in fade.alphaMaterials)
				{
					float alpha = alphaMaterial.color.a;
					alpha += fadeDelta;
					alpha = Mathf.Min(alpha, 1.0f);
					alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, alpha);
					if (alpha >= 0.99)
						totallyFadedIn++;
				}
				
				// All alpha materials are faded back to 100%
				// Thus we can switch back to the original materials
				if (totallyFadedIn == fade.alphaMaterials.Length)
				{
					if (fade.renderer)
						fade.renderer.sharedMaterials = fade.originalMaterials;
					
					foreach (Material newMaterial2 in fade.alphaMaterials)
						Destroy(newMaterial2);
					
					fadedOutObjects.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
