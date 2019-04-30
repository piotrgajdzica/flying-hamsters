using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    protected Vector2 velocity;
    protected float gravityModifier = 0.1f;
    protected float flightModifier = 1f;


    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Physics2D.gravity = new Vector2(0, -1.0F);
    }

    // Update is called once per frame
    void Update()
    {   
        float vertical = Input.GetAxis("Vertical");
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.y += vertical * Time.deltaTime;
        Vector2 position = transform.position;
        position += velocity;
        transform.position = position;
    }
}
