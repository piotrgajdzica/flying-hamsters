using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other){
		HamsterController hamster = other.GetComponent<HamsterController>();
		if(hamster != null){
			hamster.ballPowerup();
			GameObject ball = GameObject.Find("Ball");
			CollectiblePool.changeCollectiblePosition(ball);
		}
	}
}
