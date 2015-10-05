#pragma strict

var thrust: float;
var rb: Rigidbody;
var speed : float;
var count : int = 0;
var Text : UnityEngine.UI.Text;
var WinText : UnityEngine.UI.Text;

function Start () {
	rb = GetComponent.<Rigidbody>();
	updateUI(count);
}

function FixedUpdate() {
	var moveHorizontal = Input.GetAxis('Horizontal');
	var moveVertical = Input.GetAxis('Vertical');
	var movement = new Vector3 (moveHorizontal,0.0f,moveVertical);	
	rb.AddForce(movement * speed);
}

function OnTriggerEnter(other : Collider) {
	//Destroy(other.gameObject);
	if (other.gameObject.CompareTag("Pick Up")) {
		other.gameObject.SetActive (false);
		updateCount();
	}
}

var updateCount = function(){
	count = 1+count;
	updateUI(count);
};

var updateUI = function(count:int){
	Text.text = "Count: " + count;
	if(count>12){
		WinText.text = "YOU WIN!";
	}
};