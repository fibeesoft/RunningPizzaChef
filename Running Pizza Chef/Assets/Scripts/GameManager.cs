using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audios;
    public Sprite[] ingredients;
    Points points;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        points = FindObjectOfType<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPopSound()
    {
        audios.Play();
    }

    public void GameOver()
    {
        if (points)
        {
            points.SaveHighScore();
        }

        SwitchScene(0);
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
