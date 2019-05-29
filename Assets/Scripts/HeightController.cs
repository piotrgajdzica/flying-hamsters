using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightController : MonoBehaviour
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

        m_TextComponent.text = "Height: " + Mathf.Round(HamsterController.instance.rb2d.position.y / 3f + 2f) + " m";
    }
}
