using UnityEngine;
using System.Collections;

public class GlobalControlMod : MonoBehaviour {
	public int playerHealth;
	public Vector3 playerLocation;
	public Quaternion playerRotation;
	public bool savedPortalState=true;


	public static GlobalControlMod Instance;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
}
