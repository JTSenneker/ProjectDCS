//Apparently noclip is enabled with camera look movement.
//Gonna fix that, maybe add as a cheat code later? -JS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 7.0f;
	public float lookSpeedH = 2.0f;
	public float lookSpeedV = 2.0f;
	public float yaw = 0.0f;
	public float pitch = 0.0f;



	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
		//Player movement
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		//Mouse movement
		yaw += lookSpeedH * Input.GetAxis("Mouse X");
		pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		transform.Translate(strafe, 0, translation);
		if(Input.GetKeyDown("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
