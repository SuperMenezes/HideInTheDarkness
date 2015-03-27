using UnityEngine;
using System.Collections;

public class PlayerSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		Debug.Log("WOOT");
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Item")
		{
			if(other.GetComponent<ItemEvent>().Enabled)
			{
				other.GetComponent<ItemEvent>().PopUpMessage(true);
			}
		}
		
		if(other.tag == "Goal")
		{
			if(other.GetComponent<GoalEvent>().Enabled)
			{
				other.GetComponent<GoalEvent>().TriggerEvent();
			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other == null || other.tag == null)
		{
			return;
		}
		
		if(other.tag == "Item")
		{
			if(Input.GetButtonDown("Fire1")  && ! other.GetComponent<ItemEvent>().Triggered)
			{
				if(other.GetComponent<ItemEvent>().Enabled)
				{
					other.GetComponent<ItemEvent>().TriggerEvent();
				}
			}
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Item")
		{
			if(other.GetComponent<ItemEvent>().Enabled)
			{
				other.GetComponent<ItemEvent>().PopUpMessage(false);
			}
		}
	}
	
}
