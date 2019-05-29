using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowController : MonoBehaviour
{

    public const float force = 10000.0f;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void firePillow()
    {
        rb2d.AddForce(new Vector2(force, 0));
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
