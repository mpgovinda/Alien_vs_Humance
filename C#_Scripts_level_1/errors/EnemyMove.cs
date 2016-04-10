using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	Transform player;
	GameObject enemy;
	PlayerHealth playhealth;
	NavMeshAgent nav;
	bool playerInRange;
	Animator Enemyanim;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemy = GameObject.FindGameObjectWithTag ("AI");
		playhealth = player.GetComponent<PlayerHealth> ();
		nav = GetComponent<NavMeshAgent> ();
		Enemyanim = enemy.GetComponent<Animator> ();

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
		if (playhealth.currentHealth > 0 && !playerInRange) {
			nav.SetDestination (player.position);
		} 
		else if(playerInRange) {
			nav.enabled = false;
			Enemyanim.SetTrigger("inRange");
		}
	}


}
