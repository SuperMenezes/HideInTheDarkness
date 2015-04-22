using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	
	public int distance;
	
	private bool movingCamera = false;
	
	private Vector3 offsetDistance = Vector3.zero;
	
	private float maxHeight = 10f;
	private Vector3 myBehind ;
	

	// Use this for initialization
	void Start () {
		myBehind = new Vector3(0,maxHeight,-20);
		offsetDistance = (myBehind + target.position).normalized * distance;
		transform.position = target.position + offsetDistance;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetAxis("RightAxisX") > 0.2f || Input.GetAxis("RightAxisX") < -0.2f)
		{
			//offsetDistance.x+=Input.GetAxis("RightAxisX");
			transform.RotateAround(target.position, Vector3.up, Input.GetAxis("RightAxisX")*2);
			
			//transform.position = target.position + (offsetDistance.normalized * distance );
			offsetDistance = (transform.position - target.position).normalized * distance;
		}
		
		if(Input.GetAxis("RightAxisY") > 0.2f || Input.GetAxis("RightAxisY") < -0.2f)
		{
			if(Input.GetAxis("RightAxisY") < -0.2f && transform.position.y > target.position.y)
			{
				offsetDistance.y+=Input.GetAxis("RightAxisY");
			}
			
			if(Input.GetAxis("RightAxisY") > -0.2f && transform.position.y < maxHeight)
			{
				offsetDistance.y+=Input.GetAxis("RightAxisY");
			}
			
			
			transform.position = target.position + (offsetDistance.normalized * distance );
			offsetDistance = (transform.position - target.position).normalized * distance;
		}
		
		Debug.Log(Input.GetAxis("RightAxisX") + " - " + Input.GetAxis("RightAxisY"));
		//transform.RotateAround(target.position, Vector3.up, Input.GetAxis("RightAxisX"));
		//transform.Translate(Vector3.up * -Input.GetAxis("RightAxisY"));
		//transform.RotateAround(target.position, transform.right,Input.GetAxis("RightAxisY") );
		
		transform.position = target.position + (offsetDistance.normalized * distance );
		
	}
	
	void LateUpdate()
	{

		transform.LookAt(target.position);
		
		
		
		
		
	}
}
