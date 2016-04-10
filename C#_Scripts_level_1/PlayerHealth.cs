using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//namespace Buddhika 
	//[RequireComponent(typeof (ThirdPersonUserControl))]
public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int savedhealth;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	bool damaged;
	bool healing;
	Animator anim;
	bool IsDead;
	public ThirdPersonUserControl move;
	//public static PlayerHealth health;
	// Use this for initialization
	void Start () {

//		if (health == null) {
//			DontDestroyOnLoad (gameObject);
//			health = this;
//		} else if (health != this) 
//		{
//			Destroy (gameObject);
//		}

		savedhealth = GlobalControlMod.Instance.playerHealth;
		if (savedhealth!=0) {
			currentHealth = savedhealth;
			healthSlider.value = savedhealth;
		} else 
		{
			currentHealth = startingHealth;
		}
		anim = GetComponent<Animator> ();
			move = GetComponent<ThirdPersonUserControl> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		}
		else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed*Time.deltaTime);
		}
		damaged = false;
	}
	public void TakeDamage(int amount)//other scripts call this function...
	{
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !IsDead) {
			Death ();
		}
	}

	void Death(){
		IsDead = true;
		anim.SetTrigger ("Die");
		move.enabled = false;

	}

	public void Heal(int amount)//called by AR related scripts/functions
	{
		healing = true;
		currentHealth += amount;
		if (currentHealth >= startingHealth) {
			healing = false;
		}
	}
		
}


