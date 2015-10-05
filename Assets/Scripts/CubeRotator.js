#pragma strict

function Start () {

}

function Update () {
	transform.Rotate(Vector3(0,45,45)* Time.deltaTime);
}