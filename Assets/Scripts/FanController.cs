﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other){
		HamsterController hamster = other.GetComponent<HamsterController>();
		if(hamster != null){
			hamster.ForceBoost(0, 2000f);
		}
	}
}
