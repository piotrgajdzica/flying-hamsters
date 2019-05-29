using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // The namespace for the UI stuff.

public class PointsController : MonoBehaviour
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

        m_TextComponent.text = "This is the new text.";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TextComponent != null)
        {
            m_TextComponent.text = "Distance: " + Mathf.Round(HamsterController.instance.rb2d.position.x / 5f) + " m";
        }
    }
}
