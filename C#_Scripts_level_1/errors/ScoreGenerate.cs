using UnityEngine;
using System.Collections;

public class ScoreGenerate : MonoBehaviour {
	public int healthIncrement;
	public int scoreIncrement;
	PlayerHealth health;
	ScoreUpdate score;
	GameObject player;



	// Use this for initialization
	void Start () {
		healthIncrement = 50;
		scoreIncrement = 20;

		//score = GetComponent<ScoreUpdate> ();
		player=GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<PlayerHealth> ();

	}

	public void scoreUpdate(){
		ScoreUpdate.score += scoreIncrement;
	}

	public void getHealth(){
		health.Heal (healthIncrement);
	}
	// Update is called once per frame
	void Update () {
		//ScoreUpdate.score += scoreIncrement;


	}
}
