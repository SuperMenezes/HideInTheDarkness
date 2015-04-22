using UnityEngine;
using System.Collections;

public class EnableStuffEvent : Event {

	public GameObject Target;
	
	public bool TargetStatus;
	public bool RevertStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void TriggerEvent ()
	{
		Target.SetActive(true);
		
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
