using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event : MonoBehaviour {
	
	
	public bool AutoTrigger = false;
	public bool Triggered = false;
	public bool Enabled = true;
	
	public List<Event> ChainedEvents;
	public List<Event> ChainedRequirements;
	
	public virtual void TriggerEvent()
	{
	
	}

	public virtual void CheckRequirements()
	{
		foreach(Event chainedRequirement in ChainedRequirements)
		{
			if(!chainedRequirement.Triggered)
			{
				Enabled = false;
				gameObject.renderer.material.color = Color.white;
				return;
			}
		}
		Enabled = true;

		if(gameObject.renderer != null)
			gameObject.renderer.material.color = Color.red;

		Debug.Log("Evento " + gameObject.name + " habilitado!");
	}
}
