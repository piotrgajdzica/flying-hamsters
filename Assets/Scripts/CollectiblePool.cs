using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CollectiblePool : MonoBehaviour
{
    public GameObject fanPrefab;
    public GameObject torpedoPrefab;
    public GameObject ballPrefab;
    public GameObject catapultPrefab;
    public int fanCount = 0;
    public int ballCount = 0;
    public int torpedoCount = 0;
    public int catapultCount = 2;
    public int collectiblePoolSize;
    public float spawnRate = 4f;
    public static float collectibleYMin = 0f;
    public static float collectibleYMax = 30f;
    public static float collectibleXMinOffset = 10f;
    public static float collectibleXMaxOffset = 50f;

    private SpriteRenderer spriteRenderer;
    private float groundHorizontalLength;
    private GameObject[] collectibles;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

    // Start is called before the first frame update
    void Start()
    {
        collectiblePoolSize = fanCount + ballCount + torpedoCount + catapultCount;
        collectibles = new GameObject[collectiblePoolSize];
        for (int i = 0; i < fanCount; i++)
        {
            collectibles[i] = (GameObject) Instantiate(fanPrefab, objectPoolPosition, Quaternion.identity);
        }

        for (int i = fanCount; i < fanCount + ballCount; i++)
        {
            collectibles[i] = (GameObject) Instantiate(ballPrefab, objectPoolPosition, Quaternion.identity);
        }

        for (int i = fanCount + ballCount; i < fanCount + ballCount + torpedoCount; i++)
        {
            collectibles[i] = (GameObject) Instantiate(torpedoPrefab, objectPoolPosition, Quaternion.identity);
        }

        for (int i = fanCount + ballCount + torpedoCount; i < fanCount + ballCount + torpedoCount + catapultCount; i++)
        {
            collectibles[i] = (GameObject) Instantiate(catapultPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < collectiblePoolSize - catapultCount; i++)
        {
            if (GameControl.instance.gameOver == false &&
                collectibles[i].transform.position.x < HamsterController.instance.position.x - 20f)
            {
                collectibles[i].transform.position = getNewCollectiblePosition();
            }
        }
        for (int i = collectiblePoolSize - catapultCount; i < collectiblePoolSize; i++)
        {
            if (GameControl.instance.gameOver == false &&
                collectibles[i].transform.position.x < HamsterController.instance.position.x - 20f)
            {
                Vector2 vector = new Vector2(getNewCollectiblePosition().x, -7f);
                collectibles[i].transform.position = vector;
            }
        }
    }

    public static Vector2 getNewCollectiblePosition()
    {
        float hamsterXPosition = HamsterController.instance.position.x;
        float spawnYPosition = Random.Range(collectibleYMin, collectibleYMax);
        float spawnXPosition = Random.Range(hamsterXPosition + collectibleXMinOffset,
            hamsterXPosition + collectibleXMaxOffset);
        return new Vector2(spawnXPosition, spawnYPosition);
    }
}