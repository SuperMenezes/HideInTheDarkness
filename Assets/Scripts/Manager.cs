using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {



	public enum SceneState {INTRO, PLAY, CUTSCENE, END};
	
	private Timer ManagerTimer;
	
	private List<string> Intros;
	private int IntrosIndex = 0;
	
	private List<string> Outros;
	private int OutrosIndex = 0;
	
	public GUIText ManagerText;
	public NPCSpawner Spawner;

	public SceneState State {get;set;}
	
	public PlatformInputController PlayerInput;
	
	public int lives =4;
	private Timer WarningTimer;
	private bool ShowWarning = false;

	// Use this for initialization
	void Start () {
		State = SceneState.INTRO;
		ManagerTimer = new Timer(2.0f);
		
		Intros = new List<string>()	;
		Intros.Add("");
		Intros.Add("Amusement Park");
		Intros.Add("1 - 1 -> Entrance");
		Intros.Add("hide in the shadows");
		Intros.Add("avoid grown ups");
		Intros.Add("enter the park");
		Intros.Add("GO!");		
		
		Outros = new List<string>()	;
		Outros.Add("");
		Outros.Add("you win");
		Outros.Add("thanks for playing");
		Outros.Add("full version soon");
		Outros.Add("winners dont do drugs");
		Outros.Add("kthxbai");

		
		ManagerText.text = Intros[IntrosIndex];
		
		ManagerTimer.Start();
		Spawner.Status = NPCSpawner.SpawnerStatus.HOLD;
		PlayerInput.enabled = false;
		
		WarningTimer = new Timer(2.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
		switch(State)
		{
			case SceneState.INTRO:
			{
				//Debug.Log (ManagerTimer.ElapsedTime);
				if(ManagerTimer.Update())
				{	
					IntrosIndex++;
					if(IntrosIndex == Intros.Count)
					{
						ManagerText.enabled = false;
						State = SceneState.PLAY;
						PlayerInput.enabled = true;
						break;
					}
					Debug.Log(IntrosIndex);
					
					ManagerText.text = Intros[IntrosIndex];
					ManagerTimer.Reset(true);
				}
			}
			break;
			
			case SceneState.PLAY:
			{
				if(ShowWarning)
				{
					ManagerText.enabled = true;
					ManagerText.text = "hide in the shadows";
					if(WarningTimer.Update())
					{
						ShowWarning = false;
						ManagerText.enabled = false;
						WarningTimer.Reset(true);
						
					}
				}
				
				Spawner.Status = NPCSpawner.SpawnerStatus.SPAWN;
			}
			break;
			
			case SceneState.END:
			{
				if(ManagerTimer.Update())
				{	
					OutrosIndex++;
					if(OutrosIndex >= Intros.Count)
					{
						
						break;
					}
					Debug.Log(IntrosIndex);
					
					ManagerText.text = Outros[OutrosIndex];
					ManagerTimer.Reset(true);
				}
			}
			break;
		}
	}
	
	public void Win()
	{
		ManagerText.text = "";
		PlayerInput.enabled = false;
		ManagerText.enabled = true;
		Spawner.Status = NPCSpawner.SpawnerStatus.HOLD;
		State = SceneState.END;
		ManagerTimer.Reset(true);
	}
	
	public void Die()
	{
		lives--;
		
		if(lives <= 0)
		{
			ShowWarning = true;
		}
	}
}

