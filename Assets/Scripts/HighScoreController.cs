using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // The namespace for the UI stuff.

public class HighScoreController : MonoBehaviour
{
    private HamsterController hamsterController;
    private Text m_TextComponent;
    private float maxScore = 0f;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetFloat("highScore", 0f);
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
        m_TextComponent.text = "High score: " + Mathf.Round(maxScore) + " m";
    }
}

