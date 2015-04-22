using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunScript : MonoBehaviour {
	public Transform target;
	public Transform OrbitCenter;
	
	public float OrbitDegreeSpeed = 1f;
	public int OrbitRotations = 4;
	
	private float Orbits = 0;
	
	void Start()
	{
		OrbitCenter.position = Vector3.zero;
		Orbits = 0;
		//FindPerpendicular();
	}
	
	
	void Update () {
		transform.RotateAround(transform.parent.transform.position, Vector3.up, OrbitDegreeSpeed);
		
		transform.LookAt(OrbitCenter.position);
		
		//Debug.DrawLine(transform.position, transform.parent.transform.position, Color.black, 20.0f );
		//Debug.DrawRay(transform.position, target.position - transform.position,Color.black);
		
		HitTarget();
		
		
		
		
	}
	
	void HitTarget()
	{
		RaycastHit hit;
		int x = 2;
		
		MeshFilter[] mfs = target.GetComponentsInChildren<MeshFilter>();
		List<Vector3> vList = new List<Vector3>();
		foreach (MeshFilter mf in mfs) {
			vList.AddRange (mf.mesh.vertices);
		}
		
		GameObject cloneA = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cloneA.transform.position =  transform.position;
		cloneA.transform.rotation = transform.rotation;
		
		cloneA.transform.Translate(Vector3.right * 40);
		
		GameObject cloneB = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cloneB.transform.position =  transform.position;
		cloneB.transform.rotation = transform.rotation;
		
		cloneB.transform.Translate(Vector3.left * 40);
		
		Debug.DrawRay(cloneA.transform.position, cloneB.transform.position - cloneA.transform.position ,Color.blue);
		GameObject.Destroy(cloneA, 0.1f);
		GameObject.Destroy(cloneB, 0.1f);
		
		Vector3 vAX = OrbitCenter.position - transform.position;
		Vector3 vBX = target.position - transform.position;
		
		Debug.DrawRay(transform.position, vAX,Color.black);
		Debug.DrawRay(transform.position, vBX,Color.black);
		
		float angle = Vector3.Angle(vAX, vBX);
		
		Vector3 cross = Vector3.Cross(vAX, vBX);
		if (cross.y < 0) angle = -angle;
		float sinX = Mathf.Sin(angle * Mathf.Deg2Rad);
		float distanceX = Mathf.Sin(angle * Mathf.Deg2Rad) * vBX.magnitude;
		
		Debug.Log("Angulo -> " + angle);
		Debug.Log("Magnitude -> " + vBX.magnitude);
		
		
		Debug.Log("Sin(" + angle + ") -> " + sinX);
		Debug.Log("CALC -> " + distanceX);
		
		
		//for(int index = -x; index <= x; index++)
		{
			GameObject clone = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			clone.transform.position =  transform.position;
			clone.transform.rotation = transform.rotation;
			
			clone.transform.Translate(Vector3.right * distanceX);
			
			GameObject.Destroy(clone, 0.1f);
			
			//Debug.DrawRay(clone.transform.position, target.position - clone.transform.position,Color.red);
			
			foreach (Vector3 mf in vList) {
				Debug.DrawRay(clone.transform.position, (mf + target.position)-clone.transform.position ,Color.red);
			}
			
			if (Physics.Raycast(clone.transform.position, target.position - clone.transform.position, out hit)&& hit.transform.tag == "Player")
			{
				Debug.Log("HIT -> " + hit.ToString() );
				//target.GetComponent<PlayerScript>().Kill();
			}
			else
			{
				//Debug.Log("NO HIT -> " + hit.ToString() );
			}
		}
		
		
		
	}
}
