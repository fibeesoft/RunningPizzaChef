using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    Vector2 playerPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerPos = player.transform.position;
    }

    private void LateUpdate()
    {
        float x = playerPos.x + 8f;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x,y,z);
    }
}
