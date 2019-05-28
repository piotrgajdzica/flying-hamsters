using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    public static HamsterController instance;

    public const float upForce = 200f;
    public const float upNoEnergyForce = 40f;

    private bool ballShield = false;
    private bool isDead = false;
    public Rigidbody2D rb2d;
    public Vector2 position;

    public const float startingEnergy = 100.0f;
    public const float clickEnergy = 10.0f;
    public float currentEnergy;

    public Sprite armoredHamster;
 public Sprite normalHamster;

 void Awake()
    {
        currentEnergy = startingEnergy;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            rb2d = GetComponent<Rigidbody2D>();
            position = (Vector2) transform.position;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        instance.ForceBoost(GameControl.instance.initialBoost, 0);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (isDead == false)
        {
            Vector2 v = rb2d.velocity;
            float angle = Mathf.Atan2(-v.y, -v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle + 180);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (currentEnergy > clickEnergy)
                {

                    Debug.Log("upforce: " + (upForce).ToString("R"));
                    currentEnergy -= clickEnergy;
                    rb2d.AddForce(new Vector2(0, upForce));
                }
                else
                {
                    Debug.Log("no energy: " + (upNoEnergyForce).ToString("R"));
                    rb2d.AddForce(new Vector2(0, upNoEnergyForce));
                }
            }
        }

        currentEnergy = Mathf.Min(Time.deltaTime * 5 + currentEnergy, startingEnergy);
    }

    void OnCollisionEnter2D()
    {
        if (ballShield)
        {
            this.ForceBoost(0, GameControl.BOOST);
            ballShield = false;
            GetComponent<SpriteRenderer>().sprite = normalHamster;
        }
        else
        {
            Debug.Log("x" + rb2d.velocity.x);
            Debug.Log("y" + rb2d.velocity.y);
            if (rb2d.velocity.x > Mathf.Abs(rb2d.velocity.y) && rb2d.velocity.x > 2f)
            {
                Vector2 newVelocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
                rb2d.velocity = newVelocity;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                isDead = true;
                GameControl.instance.HamsterDied();
            }
        }
    }


    public void ForceBoost(float horizontal, float vertical)
    {
        rb2d.AddForce(new Vector2(horizontal, vertical));
    }

    public void ballPowerup()
    {
        this.GetComponent<SpriteRenderer>().sprite = armoredHamster;
        ballShield = true;
    }
}