using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			Debug.Log("Pressed left click.");
		
		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		
		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
			
		Debug.Log(Input.mousePosition);
	}
}
