using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	private Vector3 targetPosition = Vector3.zero;
	
	public int distance;

	
	private bool movingCamera = false;
	
	private float angleMultiplier = 0;
	
	public float RotateTime = 1.5f;
	
	
	private Vector3 offsetDistance = Vector3.zero;

	// Use this for initialization
	void Start () {
		offsetDistance = (transform.position - target.position).normalized * distance;
		transform.position = target.position + offsetDistance;
	}
	
	// Update is called once per frame
	void Update () {
	
		//if(!movingCamera)
		{
			if(Input.GetButtonDown ("LButton") )
			{
				angleMultiplier-=45;
				movingCamera = true;
			}
			else if(Input.GetButtonDown ("RButton") )
			{
				angleMultiplier+=45;
				movingCamera = true;
			}
			
			else if(Input.GetAxis ("RightAxisX") > 0.5f || Input.GetAxis ("RightAxisX") < -0.5f)
			{
				Debug.Log(Input.GetAxis("RightAxisX"));
				angleMultiplier+=Input.GetAxis("RightAxisX");
				//angleMultiplier+=45;
				movingCamera = true;
			}
		}
		
		//if(movingCamera)
		{
			Quaternion q = Quaternion.AngleAxis(angleMultiplier	, Vector3.up);
			q.z = 0;
			offsetDistance = q * offsetDistance;
			transform.position = target.position + offsetDistance;
			transform.LookAt(target.position);
			transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0));
			
			
			angleMultiplier = 0;
		}
		
	}
}
