using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;
	public bool gameOver = false;
	public const float initialBoost = 1500f;
	public static float BOOST = 1000f;
	
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }

	public void HamsterScored(){
		if(gameOver) {
			return;
		}
	}
	
	public void HamsterDied(float distance){
		gameOver = true;

        float maxScore = PlayerPrefs.GetFloat("highScore", 0f);

        if (distance > maxScore)
            PlayerPrefs.SetFloat("highScore", distance);
                

    }
}
