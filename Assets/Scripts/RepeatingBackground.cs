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
		groundCollider.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (HamsterController.instance != null){
            if (HamsterController.instance.position.x - groundHorizontalLength > transform.position.x) {
                RepositionBackgroundHorizontal();
            }
        }
    }
	
	private void  RepositionBackgroundHorizontal(){
		Vector2 groundOffset = new Vector2(groundHorizontalLength * 3f, 0);
		transform.position = (Vector2) transform.position + groundOffset;
	}
}
