using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCSpawner : MonoBehaviour {

	public enum SpawnerStatus {SPAWN, HOLD};
	public SpawnerStatus Status;	

	public GameObject Prefab;
	
	private List<GameObject> Spawned;
	public Timer SpawnTimer;
	
	// Use this for initialization
	void Start () {
		Status = SpawnerStatus.SPAWN;
		Spawned = new List<GameObject>();
		SpawnTimer = new Timer(4.0f);
		
		SpawnTimer.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
		switch(Status)
		{
			case SpawnerStatus.SPAWN:
			{
				if(SpawnTimer.Update())
				{
					GameObject newSpawn = (GameObject)Instantiate(Prefab, Prefab.transform.position, Prefab.transform.rotation);
					
					newSpawn.GetComponent<NPCEventProcessor>().EventList = new List<NPCEvent>();
					foreach(NPCEvent e in Prefab.GetComponent<NPCEventProcessor>().EventList)
					{
						NPCEvent newEvent = (NPCEvent)Instantiate(e);
						
						newSpawn.GetComponent<NPCEventProcessor>().EventList.Add(newEvent);
						//newEvent.transform.parent = newSpawn.transform;
					}
					
					newSpawn.SetActive(true);
					Spawned.Add(newSpawn);
					
					SpawnTimer.Reset(true);
				}
			}
			break;
		}
	}
}
