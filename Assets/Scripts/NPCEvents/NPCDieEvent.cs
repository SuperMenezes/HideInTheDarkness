using UnityEngine;
using System.Collections;

public class NPCDieEvent : NPCEvent {

	public float DieTimer = 1.0f;
	
	public override bool ExecuteEvent (Transform Owner)
	{
		GameObject.Destroy(Owner.gameObject, DieTimer);
		
		return true;
	}
	
}
