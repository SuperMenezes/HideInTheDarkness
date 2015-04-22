using UnityEngine;
using System.Collections;

public class ReplaceStuffEvent : Event {

	public GameObject ReplaceTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void TriggerEvent ()
	{
		ReplaceTarget.transform.position = gameObject.transform.position;
		ReplaceTarget.transform.rotation = gameObject.transform.rotation;
		
		gameObject.SetActive(false);
		ReplaceTarget.SetActive(true);
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
