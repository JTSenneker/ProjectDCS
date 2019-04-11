using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public float damage = 10f; //how much damage the gun will do
	public float range = 100f; //how far the ray will go before not registering a hit
	public Camera fpsCam;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            ps.Play();
            Shoot();
        } else if(Input.GetButtonUp("Fire1")) {
            ps.Stop();
        }   
    }

	void Shoot() {

		RaycastHit hit;
		//the line below this comment will return true if the ray hit something and it's in range, and false if it doesn't.
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			//log it to the console if we hit something
			Debug.Log(hit.transform.name);
			//get the Target component for the object that we hit.
			Target target = hit.transform.GetComponent<Target>();

			//check if there's a target component...
			if(target != null) {
				//if there is, allow the object/enemy/whatever we're shooting at to take damage
				target.TakeDamage(damage);
			}
		}
	}
}
