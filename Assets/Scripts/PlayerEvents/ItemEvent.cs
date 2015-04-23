using UnityEngine;
using System.Collections;

public class ItemEvent : Event {
	
	public string myPopUpText;
	public Font myFont;
	
	public bool DestroyOnTrigger = false;
	
	private GameObject PopUpText;
	
	public AudioClip Clip;
	
	private AudioSource Source;
	
	// Use this for initialization
	void Start () {
		CreatePopUpText();
		
		Source = gameObject.AddComponent<AudioSource>();
		Source.audio.clip = Clip;
		
		if(Enabled)
			gameObject.renderer.material.color = Color.red;
		else
			gameObject.renderer.material.color = Color.white;
	}
	
	private void CreatePopUpText()
	{
		PopUpText = new GameObject("PopUpText");
		PopUpText.AddComponent<TextMesh>();
		//		PopUpText.AddComponent<MeshRenderer>();
		
		PopUpText.GetComponent<TextMesh>().font = myFont;
		PopUpText.GetComponent<TextMesh>().text = myPopUpText;
		PopUpText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		PopUpText.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		PopUpText.GetComponent<TextMesh>().fontSize = 36;
		
		MeshRenderer meshRender = PopUpText.GetComponent<MeshRenderer>();
		
		meshRender.material = myFont.material;//(Resources.Load("Font Material") as Material);
		meshRender.materials[0] = myFont.material;//(Resources.Load("Font Material") as Material);
		
		PopUpText.transform.position = transform.position;
		//PopUpText.transform.rotation = Quaternion.LookRotation(Vector3.up);
		PopUpText.transform.Translate(new Vector3(0, 2, 0));
		
		PopUpText.transform.parent = this.transform;
		
		PopUpText.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(PopUpText.GetComponent<MeshRenderer>().enabled)
		{
			PopUpText.transform.LookAt(Camera.main.transform.position);
		}
	}
	
	public void PopUpMessage(bool visible)
	{
		PopUpText.GetComponent<MeshRenderer>().enabled = visible;
		
		if(visible && Clip != null)
		{
			Source.Play();
		}
	}

	public override void TriggerEvent ()
	{
		Triggered = true;

		foreach(Event chainedEvent in ChainedEvents)
		{
			chainedEvent.CheckRequirements();
		}
		
		Enabled = false;
		PopUpMessage(false);

		gameObject.renderer.material.color = Color.black;
	}
	
	
	
}