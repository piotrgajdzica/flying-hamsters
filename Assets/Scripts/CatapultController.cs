using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        HamsterController hamster = other.GetComponent<HamsterController>();

        if (hamster != null)
        {
            hamster.rb2d.velocity = new Vector2(hamster.rb2d.velocity.x, 0f);
            hamster.ForceBoost(GameControl.BOOST, -2 * hamster.rb2d.velocity.y + 2 * GameControl.BOOST);
        }
    }
}
