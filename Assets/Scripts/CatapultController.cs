using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        HamsterController hamster = other.GetComponent<HamsterController>();
        if(hamster != null){
            hamster.ForceBoost(GameControl.BOOST / 2, GameControl.BOOST / 2);
            GameObject catapult = GameObject.Find("Catapult");
            CollectiblePool.changeCollectiblePosition(catapult);
        }
    }
}
