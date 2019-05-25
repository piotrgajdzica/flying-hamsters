using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{

	public static HamsterController instance;

    public float upForce = 2000f;
    public float upNoEnergyForce = 20f;

    private bool ballShield = false;
	private bool isDead = false;
	public Rigidbody2D rb2d;
	public Vector2 position;

    public float startingEnergy = 100;
    public float clickEnergy = 100;
    public float currentEnergy;


    void Awake()
    {
        currentEnergy = startingEnergy;
    }

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
		instance.ForceBoost(GameControl.instance.initialBoost, 0);

	}

	// Update is called once per frame
	void Update()
	{
		position = transform.position;
		if(isDead == false){
            
            Vector2 v = rb2d.velocity;
            float angle = Mathf.Atan2(v.y, GameControl.instance.initialBoost) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -angle + 180);

            if (Input.GetMouseButtonDown(0))
            {
	            if (currentEnergy > clickEnergy)
               {
                    currentEnergy -= clickEnergy;
                    rb2d.AddForce(new Vector2(0, upForce));
                }
                else
                {

                    rb2d.AddForce(new Vector2(0, upNoEnergyForce));
                }
            }
        }
        currentEnergy = Mathf.Min(Time.deltaTime * 5 + currentEnergy, startingEnergy);

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
		//rb2d.velocity = Vector2.zero;
		rb2d.AddForce(new Vector2(horizontal, vertical));
	}

	public void ballPowerup(){
		ballShield = true;
	}
}
