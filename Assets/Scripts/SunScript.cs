using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	public Transform target;
	
	public float OrbitDegreeSpeed = 1f;
	public int OrbitRotations = 4;
	
	private float Orbits = 0;
	
	void Start()
	{
		Orbits = 0;
	}
	
	
	void Update () {
		transform.RotateAround(transform.parent.transform.position, Vector3.up, OrbitDegreeSpeed);
		
		transform.LookAt(Vector3.zero);
		
		RaycastHit hit;
		if (Physics.Raycast(transform.position, target.position - transform.position, out hit)&& hit.transform.tag == "Player")
		{
			Debug.Log("HIT -> " + hit.ToString() );
			target.GetComponent<PlayerScript>().Kill();
		}
		else
		{
			//Debug.Log("NO HIT -> " + hit.ToString() );
		}
		/*
		if (!Physics.Raycast (transform.position, target.position)) {
			Debug.Log("HIT");
		}
		else
		{
			Debug.Log("NO HIT");
		}
		*/
	}
}
