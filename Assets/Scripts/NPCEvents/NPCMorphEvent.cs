using UnityEngine;
using System.Collections;

public class NPCMorphEvent : NPCEvent {

	public Event RequiredEvent;
	public GameObject MorphTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override bool ExecuteEvent (Transform Owner)
	{
		if(RequiredEvent.Triggered)
		{
			//REPLACE MESH
			
			//REPLACE MATERIALS
			Owner.renderer.materials = MorphTarget.renderer.materials;
			
			//REPLACE EVENT LIST
			Owner.GetComponent<NPCEventProcessor>().Reset();
			foreach(NPCEvent e in MorphTarget.GetComponent<NPCEventProcessor>().EventList)
			{
				NPCEvent newEvent = (NPCEvent)Instantiate(e);
				Owner.GetComponent<NPCEventProcessor>().EventList.Add(newEvent);
			}
			Owner.GetComponent<NPCEventProcessor>().Restart();
			
		}
		
		return true;
	}
}
