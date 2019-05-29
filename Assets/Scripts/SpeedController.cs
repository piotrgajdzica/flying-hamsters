using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    private HamsterController hamsterController;
    private Text m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        // Get a reference to the text component
        m_TextComponent = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {

        m_TextComponent.text = "Speed: " + Math.Round(Mathf.Sqrt(Mathf.Pow(HamsterController.instance.rb2d.velocity.x / 5f, 2.0f) + Mathf.Pow(HamsterController.instance.rb2d.velocity.y / 3f, 2f)), 1) + " m/s";
    }
}
