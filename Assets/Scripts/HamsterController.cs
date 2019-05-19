using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    public Rigidbody2D rb;
    //protected float gravityModifier = 0.1f;
    protected float flightModifier = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Physics2D.gravity = new Vector2(0, -1.0F);
    }

    // Update is called once per frame
    void Update()
    {   
        float vertical = Input.GetAxis("Vertical");

        if(vertical != 0f){
            //Unlock all
            rb.constraints = RigidbodyConstraints2D.None;
        }

        //velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        Vector2 velocity = rb.velocity;
        velocity.y += vertical * Time.deltaTime * flightModifier;
        rb.velocity = velocity;


        Vector2 v = rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        /*Vector2 position = rb.position;
        position += rb.velocity;
        transform.position = position;*/
    }
}
