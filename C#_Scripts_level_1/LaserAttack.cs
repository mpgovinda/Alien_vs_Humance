using UnityEngine;
using System.Collections;

public class LaserAttack : MonoBehaviour {
	public float timeBetweenAttacks=0.5f;
	public int attackDamage=10;
	public GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}


	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange) {
			Attack (); 
		}
	}

	void Attack()
	{
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
