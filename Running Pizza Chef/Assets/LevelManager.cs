using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Transform[] walkingGrounds;
    Transform player;

    Vector3 walkingGroundCurrentPos;
    Vector3 walkingGroundNextPos;
    float walkingGroundNextPosShiftX = 40f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        walkingGroundCurrentPos = new Vector3(0f, -4.7f);
        walkingGrounds[0].position = walkingGroundCurrentPos;
    }

    void SwitchWalkingGrounds()
    {
        walkingGroundNextPos = new Vector3(walkingGroundCurrentPos.x + walkingGroundNextPosShiftX, walkingGroundCurrentPos.y, walkingGroundCurrentPos.z);
        if(walkingGrounds[0].position == walkingGroundCurrentPos)
        {
            walkingGrounds[1].position = walkingGroundNextPos;
        }
        else if(walkingGrounds[1].position == walkingGroundCurrentPos)
        {
            walkingGrounds[0].position = walkingGroundNextPos;
        }
        walkingGroundCurrentPos = walkingGroundNextPos;
    }

    void Update()
    {
        if(player.position.x > walkingGroundCurrentPos.x)
        {
            SwitchWalkingGrounds();
        }
    }
}
