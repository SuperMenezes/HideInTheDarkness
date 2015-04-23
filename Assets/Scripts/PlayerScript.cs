using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Manager SceneManager;
	


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(SceneManager.State == Manager.SceneState.PLAY)
		{
			if(!IsInsideSafeZone())
			{
				transform.position = transform.parent.position;
				audio.Play();
				
				SceneManager.Die();
			}
		}
	}
	
	public void Kill()
	{
		
		transform.position = transform.parent.position;

	}
	
	private bool IsInsideSafeZone()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("MoveZone"))
		{
			MoveZone script = obj.GetComponent<MoveZone>();
			if(script.Enabled && obj.transform.collider.bounds.Contains(transform.position))
			{
				return true;
			}
		}
		return false;
	}
	
}
