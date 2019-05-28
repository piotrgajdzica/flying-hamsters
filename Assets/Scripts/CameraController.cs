using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float minimumBoundary = 4f;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector2 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x + offset.x,
            Mathf.Clamp(playerPosition.y + offset.y, minimumBoundary, float.MaxValue), -10f);
    }
}