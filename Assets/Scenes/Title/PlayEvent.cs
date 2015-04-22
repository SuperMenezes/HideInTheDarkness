using UnityEngine;
using System.Collections;

public class PlayEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.red;
	}
	
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}
	
	public void OnMouseUp()
	{
		Application.LoadLevel("Prototype2");
	}
}
