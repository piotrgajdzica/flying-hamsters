using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        HamsterController hamster = other.GetComponent<HamsterController>();
        Debug.Log("boost: " + GameControl.BOOST);
        Debug.Log("velocity: " + hamster.rb2d.velocity.y);

        hamster.rb2d.velocity = new Vector2(hamster.rb2d.velocity.x, 0f);

        if (hamster != null){
            hamster.ForceBoost(GameControl.BOOST / 2, -2 * hamster.rb2d.velocity.y + GameControl.BOOST);
        }
    }
}
