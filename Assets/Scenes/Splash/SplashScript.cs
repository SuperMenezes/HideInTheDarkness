using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	private Timer SplashTimer;
	private Timer KarpTimer;
	
	// Use this for initialization
	void Start () {
		
		SplashTimer = new Timer(3.0f);
		SplashTimer.Start();
		gameObject.audio.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(SplashTimer.Update())
		{
			Application.LoadLevel("Title");
		}
		
	}
}
