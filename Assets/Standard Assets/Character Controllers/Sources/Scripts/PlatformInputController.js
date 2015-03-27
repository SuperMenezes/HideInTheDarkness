// This makes the character turn to face the current movement speed per default.
var autoRotate : boolean = true;
var maxRotationSpeed : float = 360;

var moveDirection = Vector3.zero; // Direction we're moving in.
var targetDirection = Vector3.zero; // Direction we want to move in.
 
var rotateSpeed = 5; // Speed to rotate at.
var moveSpeed = 5; // Speed to move at.

private var motor : CharacterMotor;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}

// Update is called once per frame
function Update () {
	    // Get forward direction of the player object.
    moveDirection = transform.TransformDirection(Vector3.forward);
   
    // Get forward direction of the camera.
    var forward = Vector3.Normalize(Vector3.Scale(camera.main.transform.TransformDirection(Vector3.forward), Vector3(1, 0, 1)));
    var right = Vector3(forward.z, 0, -forward.x);
 
    // Blend the two so movement tries to be relative to forwards of the camera.
    targetDirection = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;
   
    if (targetDirection != Vector3.zero)
    {
        moveDirection = Vector3.Lerp(moveDirection, targetDirection, rotateSpeed * Time.deltaTime);
        moveDirection = moveDirection.normalized;
    }
   
    //controller.Move(moveDirection * moveSpeed * Time.deltaTime);
}

function ProjectOntoPlane (v : Vector3, normal : Vector3) {
	return v - Vector3.Project(v, normal);
}

function ConstantSlerp (from : Vector3, to : Vector3, angle : float) {
	var value : float = Mathf.Min(1, angle / Vector3.Angle(from, to));
	return Vector3.Slerp(from, to, value);
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/Platform Input Controller")
