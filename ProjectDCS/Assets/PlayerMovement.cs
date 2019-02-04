//Apparently noclip is enabled with camera look movement.
//Gonna fix that, maybe add as a cheat code later? -JS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 7.0f;
	public float sensitivity = 1.0f;
	public Vector2 pitchBounds;
	public Transform eyes;

	private float yaw;
	private float pitch;
	private float moveH;
	private float moveV;


	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
		//Player movement
		moveH = Input.GetAxis("Horizontal");
		moveV = Input.GetAxis("Vertical");

		transform.position += transform.forward * moveV * speed * Time.deltaTime;
		transform.position += transform.right * moveH * speed * Time.deltaTime;

		//Mouse movement
		yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		pitch = Mathf.Clamp(pitch, pitchBounds.x, pitchBounds.y);

		transform.rotation = Quaternion.Euler(0, yaw, 0);
		eyes.localEulerAngles = new Vector3(pitch, 0, 0);

		if(Input.GetKeyDown("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
    }
}