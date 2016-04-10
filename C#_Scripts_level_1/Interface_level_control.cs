using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Interface_level_control : MonoBehaviour {
	GameObject currentplayer;
	public PlayerStates state;
	public PlayerHealth healthset;
	public ThirdPersonUserControl locate;
	//ScoreUpdate scoreset;
		public void NextLevelButton(int index)
		{
		//DontDestroyOnLoad(currentplayer);
		SceneManager.LoadScene (index);
		}

		public void NextLevelButton(string levelName)
		{
		//locate.saveLocation ();
		//healthset.SaveHealth ();


		SceneManager.LoadScene (levelName);
		state.SaveState ();
		}
	
	// Use this for initialization
	void Start () {
		//currentplayer = GameObject.FindGameObjectWithTag ("Player");
	//	state = currentplayer.GetComponent<PlayerState> ();
		//locate = currentplayer.GetComponent<ThirdPersonUserControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
