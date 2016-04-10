using UnityEngine;
using System.Collections;

public class ObjectHighlighter : MonoBehaviour {

	bool isHighlighted = false;
	Material originalMaterial;
	Material redMaterial;
	MeshRenderer meshRenderer;

	int healthadd=20;
	int scoreadd=10;
	GameObject baseObject;

	public GameObject Glow;
	string obj_name;
	// Use this for initialization
	void Start () {

		obj_name 			= this.gameObject.name + "Base";
		baseObject 			= GameObject.FindGameObjectWithTag("Collectible");
		meshRenderer 		= baseObject.GetComponent<MeshRenderer>();
//		originalMaterial 	= meshRenderer.material;

		Color red 			= new Color(255.0f,0.0f,0.0f, 0.5f);
		redMaterial  		= new Material(Shader.Find("Standard"));
		redMaterial.color 	= red;

		Glow.SetActive(false);

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){

		Debug.Log("OMD "+obj_name);
		isHighlighted = !isHighlighted;

		if( isHighlighted ){

			HighlightRed();

		}else{

			RemoveHighlight();
		}
	}

	void HighlightRed(){

		Glow.SetActive(true);
		//meshRenderer.material = redMaterial;
		ScoreUpdate.score += scoreadd;

			GlobalControlMod.Instance.playerHealth += healthadd;
		

	}

	void RemoveHighlight(){

		Glow.SetActive(false);
		//meshRenderer.material = originalMaterial;
	}
}
