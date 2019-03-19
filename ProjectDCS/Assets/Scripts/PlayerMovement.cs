using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 7.0f; //walk speed
	public Transform eyes; //camera child object of the player
    public Rigidbody rb;
    bool isOnGround = true;
    public float jumpForce = 5.0f; //how high the player jumps

    public float mouseSensitivity = 100.0f; //mouse look speed/right analog stick look speed, default 100
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

	private float moveH = 0.0f;
	private float moveV = 0.0f;

    public int seconds = 0;
    public int minutes = 0;

    public int health = 100;
    public int maxHealth = 100;
    private float speedBoost = 1.0f; // Factor of 1. 0.9 = 90%; 2.0 = 200%
    public int speedCooldown = 0; // Cooldown in  seconds.

    void Start() {
        // Make the rigid body not change rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        // Start up movement.
        moveH = 0.0f;
        moveV = 0.0f;
        // Other
        Cursor.lockState = CursorLockMode.Locked; //hide cursor
        rb = GetComponent<Rigidbody>();
        // Invoke
        InvokeRepeating("PerSecondUpdate", 0.0f, 1.0f);
    }

    void OnCollisionStay() {
        isOnGround = true;
    }

    void Update() {
        //Player movement
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        transform.position += transform.forward * moveV * speedBoost * speed * Time.deltaTime;
        transform.position += transform.right * moveH * speedBoost * speed * Time.deltaTime;

        //Mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        transform.rotation = localRotation;
        eyes.localRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);

        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None; //show cursor
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Speed_Small_Prefab")) {
            other.gameObject.SetActive(false);
            AddSpeed("s");
        } else if (other.gameObject.CompareTag("Speed_Normal_Prefab")) {
            other.gameObject.SetActive(false);
            AddSpeed("n");
        } else if (other.gameObject.CompareTag("Speed_Big_Prefab")) {
            other.gameObject.SetActive(false);
            AddSpeed("b");
        }
    }

    void AddSpeed(string size) {
        switch (size) {
            case "s":
            case "small":
                speedCooldown = 5;
                speedBoost = 1.2f;
                break;
            case "n":
            case "normal":
                speedCooldown = 10;
                speedBoost = 1.7f;
                break;
            case "b":
            case "big":
                speedCooldown = 15;
                speedBoost = 2.0f;
                break;
            default:
                break;
        }
    }

    void PerSecondUpdate() {
        seconds++;
        if (seconds >= 60) {
            minutes++;
            seconds = 0;
        }
        //if (speedCooldown > 0) { speedCooldown--; Debug.Log($"Cooldown: {speedCooldown} | Boost: {speedBoost}"); }
        if (speedCooldown == 0) speedBoost = 1;
    }
}