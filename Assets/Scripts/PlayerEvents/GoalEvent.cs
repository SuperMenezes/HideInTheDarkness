using UnityEngine;
using System.Collections;

public class GoalEvent : Event {

	public Manager SceneManager;


	public override void TriggerEvent ()
	{
		SceneManager.Win();
	}

}
