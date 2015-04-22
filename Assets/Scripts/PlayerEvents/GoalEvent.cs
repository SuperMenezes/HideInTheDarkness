using UnityEngine;
using System.Collections;

public class GoalEvent : Event {


	public override void TriggerEvent ()
	{
		GetComponentInChildren<GUIText>().enabled = true;
		
		Debug.Log("TriggerEvent");
		
		Triggered = true;
		
		foreach(Event chainedEvent in ChainedEvents)
		{
			chainedEvent.CheckRequirements();
		}
		
		Enabled = false;
	}

}
