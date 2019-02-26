using UnityEngine;

public class Target : MonoBehaviour {
	public float health = 50f;
  

	public void TakeDamage(float damageAmount) {
		health -= damageAmount;
		if(health <= 0) {
			Die();
		}
	}

	void Die() {
		gameObject.SetActive(false);
	}
}
