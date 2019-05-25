using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePool : MonoBehaviour
{

	public int collectiblePoolSize = 15;
	public GameObject fanPrefab;
	public GameObject torpedoPrefab;
	public GameObject ballPrefab;
	public float spawnRate = 4f;
	public static float collectibleYMin = 0f;
	public static float collectibleYMax = 30f;
	public static float collectibleXMinOffset = 10f;
	public static float collectibleXMaxOffset = 40f;

	private SpriteRenderer spriteRenderer;
	private float groundHorizontalLength;
	private GameObject[] collectibles;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

    // Start is called before the first frame update
    void Start()
    {
		collectibles = new GameObject[collectiblePoolSize];
		for(int i = 0; i < collectiblePoolSize; i = i + 3){
			collectibles[i] = (GameObject) Instantiate(fanPrefab, objectPoolPosition, Quaternion.identity);
			collectibles[i + 1] = (GameObject) Instantiate(ballPrefab, objectPoolPosition, Quaternion.identity);
			collectibles[i + 2] = (GameObject) Instantiate(torpedoPrefab, objectPoolPosition, Quaternion.identity);
		}
    }

    // Update is called once per frame
    void Update()
    {
		for(int i = 0; i < collectiblePoolSize; i++){
			if(GameControl.instance.gameOver == false && collectibles[i].transform.position.x < HamsterController.instance.position.x - 10f){
				changeCollectiblePosition(collectibles[i]);
			}
		}
    }

	public static void  changeCollectiblePosition(GameObject collectible){
		float hamsterXPosition = HamsterController.instance.position.x;
		float spawnYPosition = Random.Range (collectibleYMin, collectibleYMax);
		float spawnXPosition = Random.Range (hamsterXPosition + collectibleXMinOffset ,hamsterXPosition + collectibleXMaxOffset);
		collectible.transform.position = new Vector2(spawnXPosition, spawnYPosition);
	}
}
