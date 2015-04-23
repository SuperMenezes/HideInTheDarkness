using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NPCEventProcessor : MonoBehaviour {

	public List<NPCEvent> EventList;
	public int EventIndex;
	
	private NPCEvent CurrentEvent;
	

	// Use this for initialization
	void Start () {
		EventIndex = 0;
		CurrentEvent = EventList[EventIndex];
		//Debug.Log("Fetch Event: " + CurrentEvent.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentEvent != null)
		{
			if(CurrentEvent.ExecuteEvent(transform))
			{
				EventIndex++;
				if(EventIndex == EventList.Count)
				{
					CurrentEvent = null;
					return;	
				}
				CurrentEvent = EventList[EventIndex];
				//Debug.Log("Fetch Event: " + CurrentEvent.name);
			}
		}
	}
	
	void OnDestroy () {
		foreach(NPCEvent e in EventList)
		{
			if(e != null)
				Destroy(e.gameObject);
		//Debug.Log("DESTROY");
		}
	}
	
	public void Reset()
	{
		foreach(NPCEvent e in EventList)
		{
			Destroy(e.gameObject);
		}
		EventList.Clear();
	}
	
	public void Restart()
	{
		EventIndex = -1;
	}
}
