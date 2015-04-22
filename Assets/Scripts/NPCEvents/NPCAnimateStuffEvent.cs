using UnityEngine;
using System.Collections;

public class NPCAnimateStuffEvent : NPCEvent {

	public GameObject Target;
	public string AnimationName;
	public bool WaitFinishedPlay = false;
	private bool Triggered = false;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override bool ExecuteEvent (Transform Owner)
	{
		if(!Triggered)
		{
			if(Target.activeInHierarchy)
			{
				Target.animation.Play(AnimationName);
				Triggered = true;
			}
		}
		else
		{
			if(!Target.animation.IsPlaying(AnimationName))
			{
				return false;
			}
		}
		
		if(!WaitFinishedPlay)
		{
			return true;
		}
		
		return false;
	}
}
