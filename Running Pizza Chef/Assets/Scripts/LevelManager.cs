using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Transform player;

    [SerializeField]
    Transform[] walkingGrounds;
    Vector3 walkingGroundCurrentPos;
    Vector3 walkingGroundNextPos;
    Vector3 shiftX = new Vector3(40f,0f,0f);

    [SerializeField] GameObject[] levelPanels;
    [SerializeField] GameObject star;
    GameObject currentLevelPanel;
    GameObject nextLevelPanel;
    Vector3 currentLevelPanelPos;
    Vector3 nextLevelPanelPos;
    int currentLevelPanelIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        walkingGroundCurrentPos = new Vector3(0f, -4.7f);
        walkingGrounds[0].position = walkingGroundCurrentPos;

        currentLevelPanel = levelPanels[0];
        currentLevelPanel.transform.position = Vector3.zero;
        currentLevelPanelIndex = 0;

        InvokeRepeating("PositionStarOnTheScene", 5f, 12f);
    }

    void PositionStarOnTheScene()
    {
        float rand = Random.Range(-3.8f, 4.2f);
        Vector3 shiftStarPos = new Vector3(12f, rand, 0f);
        star.transform.position = new Vector3(player.transform.position.x + shiftStarPos.x, rand, 0f);
    }

    void SwitchNextLevelPanel()
    {
        nextLevelPanelPos = currentLevelPanelPos + shiftX;
        int randomLevelPanelIndex = Random.Range(0, levelPanels.Length);
        while (randomLevelPanelIndex == currentLevelPanelIndex)
        {
            randomLevelPanelIndex = Random.Range(0, levelPanels.Length);
        }
        currentLevelPanelIndex = randomLevelPanelIndex;
        nextLevelPanel = levelPanels[randomLevelPanelIndex];

        nextLevelPanel.transform.position = nextLevelPanelPos;

        Ingredient[] ingredients = Resources.FindObjectsOfTypeAll<Ingredient>();

        foreach(var i in ingredients)
        {
            i.gameObject.SetActive(true);
        }

        currentLevelPanelPos = nextLevelPanelPos;
    }

    void SwitchWalkingGrounds()
    {
        walkingGroundNextPos = walkingGroundCurrentPos + shiftX;
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

        if(player.position.x > currentLevelPanelPos.x)
        {
            SwitchNextLevelPanel();
        }
    }
}
