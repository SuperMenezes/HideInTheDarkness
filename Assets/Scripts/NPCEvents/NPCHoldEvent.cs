using UnityEngine;
using System.Collections;

public class NPCHoldEvent : NPCEvent {

	private Timer HoldTimer;
	public float HoldTime = 0.0f;
		
	void Start()
	{
		HoldTimer = new Timer(HoldTime);
		HoldTimer.Start();
	}
	
	public override bool ExecuteEvent (Transform Owner)
	{
		return HoldTimer.Update();
	}
	
}
