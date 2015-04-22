using UnityEngine;
using System.Collections;

public class TextureMeshEvent : Event {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void TriggerEvent ()
	{
		gameObject.renderer.enabled = true;
	}
	
	public override void CheckRequirements ()
	{
		base.CheckRequirements ();
		
		if(Enabled && AutoTrigger)
		{
		
			TriggerEvent();
		
		}
	}
}
