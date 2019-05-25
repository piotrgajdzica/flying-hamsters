using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{

	public static HamsterController instance;

	public float upForce = 2000f;

	private bool ballShield = false;
	private bool isDead = false;
	private Rigidbody2D rb2d;
	public Vector2 position;

	// Start is called before the first frame update
	void Start()
	{
		if(instance == null){
			instance = this;
			rb2d = GetComponent<Rigidbody2D>();
			position = (Vector2)transform.position;
		}
		else if(instance != this){
			Destroy(gameObject);
		}

	}

	// Update is called once per frame
	void Update()
	{
		position = transform.position;
		if(isDead == false){
			if(Input.GetMouseButtonDown(0)){
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D()
	{
		if(ballShield){
			this.ForceBoost(0, GameControl.BOOST);
			ballShield = false;
		}
		else{
			rb2d.velocity = Vector2.zero;
			isDead = true;
			GameControl.instance.HamsterDied();
		}
	}


	public void ForceBoost(float horizontal, float vertical){
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(new Vector2(horizontal, vertical));
	}

	public void ballPowerup(){
		ballShield = true;
	}
}
