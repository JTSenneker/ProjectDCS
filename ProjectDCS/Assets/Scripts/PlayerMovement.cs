using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 7.0f; //walk speed
	public float sensitivity = 20.0f; //mouse look speed/right analog stick look speed, default 20
	public Vector2 pitchBounds; //limits of how far we can look up or down, X default is -72, Y default is 73
	public Transform eyes; //camera child object of the player
    public Rigidbody rb;
    bool isOnGround = true;   
    public float jumpForce = 5.0f; //how high the player jumps

    private float yaw;
	private float pitch;
	private float moveH;
	private float moveV;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked; //hide cursor
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay() {
        isOnGround = true;
    }

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
			Cursor.lockState = CursorLockMode.None; //show cursor
		}

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    //private bool isGrounded() {
    //   return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, 
    //       collider.bounds.min.y, collider.bounds.center.z), collider.radius * .9f);
    //}
}