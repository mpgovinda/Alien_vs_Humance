using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {
	public PlayerHealth health;
	public GameObject Player;
	//public GameObject portal;
	//public GoToAR AR;
	// Use this for initialization
	void Start () {
		health = GetComponent<PlayerHealth> ();
		//portal = GameObject.FindGameObjectWithTag ("ARportal");
		//AR = portal.GetComponent<GoToAR> ();

		transform.position = GlobalControlMod.Instance.playerLocation;
		health.currentHealth = GlobalControlMod.Instance.playerHealth;
		transform.rotation = GlobalControlMod.Instance.playerRotation;
	}

	public void SaveState()
	{
		GlobalControlMod.Instance.playerLocation = transform.position;
		GlobalControlMod.Instance.playerHealth = health.currentHealth;
		GlobalControlMod.Instance.playerRotation = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
