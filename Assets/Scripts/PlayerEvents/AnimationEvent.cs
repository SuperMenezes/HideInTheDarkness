using UnityEngine;
using System.Collections;

public class AnimationEvent : Event {

	public string AnimationName = "";
	
	void Start()
	{
		//animation[AnimationName].time = 0.0f;
		
		//AnimationState clipState = animation.GetClip( AnimationName );
		//clipState.normalizedTime = 1.0f;
		animation.Play();
		animation.Sample(); //forces the pose to be calculated
		animation.Stop();
	}
	
	public override void TriggerEvent ()
	{
		gameObject.animation.Play(AnimationName);
		Debug.Log(AnimationName);
	}
	
	public override void CheckRequirements ()
	{
		base.CheckRequirements ();
		
		if(Enabled && AutoTrigger)
		{
			
			TriggerEvent();
			
		}
	}
}
