using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RepeatingBackground : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;
	private float groundVerticalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		groundHorizontalLength = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
		groundVerticalLength = spriteRenderer.sprite.bounds.size.y * transform.localScale.y;
		EnableGroundCollider();

    }

    // Update is called once per frame
    void Update()
    {
        if(HamsterController.instance.position.x - groundHorizontalLength > transform.position.x){
			RepositionBackgroundHorizontal();
		}
		if(HamsterController.instance.position.y > transform.position.y){
			RepositionBackgroundVerticalAbove();
		}
		if(HamsterController.instance.position.y < transform.position.y - groundVerticalLength ){
			RepositionBackgroundVerticalBelow();
		}
		EnableGroundCollider();
    }
	
	private void  RepositionBackgroundHorizontal(){
		Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
		transform.position = (Vector2) transform.position + groundOffset;
	}

	private void  RepositionBackgroundVerticalAbove(){
		Vector2 groundOffset = new Vector2(0, groundVerticalLength * 2f);
		transform.position = (Vector2) transform.position + groundOffset;
	}

	private void  RepositionBackgroundVerticalBelow(){
		Vector2 groundOffset = new Vector2(0, -groundVerticalLength * 2f);
		transform.position = (Vector2) transform.position + groundOffset;
	}

	private void EnableGroundCollider(){
		if(transform.position.y < groundVerticalLength){
			groundCollider.enabled = true;
		} else {
			groundCollider.enabled = false;
		}
	}
}
