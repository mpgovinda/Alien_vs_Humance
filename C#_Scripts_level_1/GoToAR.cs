using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoToAR : MonoBehaviour {
	GameObject player;
	ParticleSystem lights;
	PlayerStates Curreentstate;
	public bool currentPortalstate;
	public CapsuleCollider portal;
	// Use this for initialization
	void Start () {
		currentPortalstate = GlobalControlMod.Instance.savedPortalState;

		player = GameObject.FindGameObjectWithTag ("Player");
		lights = GetComponent<ParticleSystem> ();
		portal = lights.GetComponent<CapsuleCollider> ();
		if (currentPortalstate == false) {
			portal.isTrigger = false;
			lights.enableEmission = false;
		}

		Curreentstate = player.GetComponent<PlayerStates> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			GlobalControlMod.Instance.savedPortalState = false;
			Curreentstate.SaveState ();
			
			SceneManager.LoadScene ("Augmented Reality");

		}
	
	}
}
