using UnityEngine;
using System.Collections;

public class NPCEnableStuffEvent : NPCEvent {

	public GameObject Target;
	public bool TargetState;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override bool ExecuteEvent (Transform Owner)
	{
		Target.SetActive(TargetState);
		return true;
	}
}
