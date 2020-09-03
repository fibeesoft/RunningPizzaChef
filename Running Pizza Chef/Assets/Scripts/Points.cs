using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] Text txtPoints;
    int points = 0;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        DisplayPoints();
    }

    public void AddPoints(int points)
    {
        this.points += points;
        DisplayPoints();
        CheckIfNumberOfPointsIsNotLessThanZero();
    }

    public void TakePoints(int points)
    {
        this.points -= points;
        DisplayPoints();
        CheckIfNumberOfPointsIsNotLessThanZero();
    }

    void DisplayPoints()
    {
        txtPoints.text = points.ToString();
    }

    void CheckIfNumberOfPointsIsNotLessThanZero()
    {
        if(points < 0)
        {
            gameManager.GameOver();
        }
    }
}
