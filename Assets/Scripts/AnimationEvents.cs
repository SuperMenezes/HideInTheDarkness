using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour {

	public GameObject Catraca;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DisableCatraca()
	{
		Catraca.SetActive(false);
		//Destroy(Target);
	}
}
