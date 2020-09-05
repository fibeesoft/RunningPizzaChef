using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] Text txtPoints;
    int points = 0;
    string highScoreKey = "highScore";
    GameManager gameManager;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(highScoreKey))
        {
            PlayerPrefs.SetInt(highScoreKey, 0);
        }
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        DisplayPoints();
    }

    public void SaveHighScore()
    {
        if(points > PlayerPrefs.GetInt(highScoreKey))
        {
            PlayerPrefs.SetInt(highScoreKey, points);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScoreKey);
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
