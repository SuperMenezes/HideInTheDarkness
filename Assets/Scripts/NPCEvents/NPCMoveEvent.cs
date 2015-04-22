using UnityEngine;
using System.Collections;

public class NPCMoveEvent : NPCEvent {

	public Transform TargetPosition;
	public float MoveTime = 2.0f;
	private float LerpTime = 0.0f;

	public override bool ExecuteEvent (Transform Owner)
	{
		LerpTime += Time.deltaTime;
		
		if(LerpTime > MoveTime)
		{
			LerpTime = MoveTime;
			return true;
		}
		
		if(TargetPosition == null)
		{
			return true;
		}
		
		float LerpPercent = LerpTime/MoveTime;
		Debug.Log("Lerp % = " + LerpPercent);
		
		Owner.position = Vector3.Lerp(transform.position, TargetPosition.position, LerpPercent);
		
		Owner.LookAt(TargetPosition);
		return false;
	}

}
