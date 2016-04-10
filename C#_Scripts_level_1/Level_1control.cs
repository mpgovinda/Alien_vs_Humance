using UnityEngine;
using System.Collections;

public class Level_1control : MonoBehaviour {
	public static Level_1control level1;
	// Use this for initialization
	void Start () {
		if (level1 == null) {
			DontDestroyOnLoad (gameObject);
			level1 = this;
		} else if (level1 != this) 
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
