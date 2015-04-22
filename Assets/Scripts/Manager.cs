using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public enum SceneState {INTRO, PLAY, CUTSCENE, END};
	
	public SceneState State {get;set;}

	// Use this for initialization
	void Start () {
		State = SceneState.PLAY;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
