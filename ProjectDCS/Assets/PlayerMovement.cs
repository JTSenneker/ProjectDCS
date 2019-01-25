using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 7.0f;
	public float lookSpeed = 5.0f;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		float lookX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float lookY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

		transform.Translate(strafe, 0, translation);
		if(Input.GetKeyDown("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
