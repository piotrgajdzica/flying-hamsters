using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other){
		HamsterController hamster = other.GetComponent<HamsterController>();
		if(hamster != null){
			hamster.ForceBoost(GameControl.BOOST, 0);
			transform.position = CollectiblePool.GetNewCollectiblePosition();
		}
	}
}
