using UnityEngine;
using System.Collections;

public abstract class NPCEvent : MonoBehaviour {

	public GameObject ParentNPC;

	
	public abstract bool ExecuteEvent(Transform Owner);
}
