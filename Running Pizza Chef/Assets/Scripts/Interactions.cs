using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    UIManager uiManager;
    Points points;
    GameManager gameManager;
    int ingredientID;
    bool isStarSelected = false;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        points = FindObjectOfType<Points>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ingredient>())
        {
            ingredientID = collision.GetComponent<Ingredient>().IngredientID;
            CheckIfTheRightIngredientWasCollected();
            collision.GetComponent<Ingredient>().SwitchCollectAnimation();
            gameManager.PlayPopSound();
            if (!isStarSelected)
            {
                uiManager.AssignRandomImageToTheBtnIngredient();
            }

        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }

        else if (collision.transform.CompareTag("Star"))
        {
            TurnStarOn();
            collision.transform.position = new Vector3(0f, 30f, 0f);
        }
    }

    void TurnStarOn()
    {
        isStarSelected = true;
        uiManager.MakeButtonInteractive(false);
        uiManager.AssignStarImage();
        StartCoroutine(TurnStar());

        IEnumerator TurnStar()
        {
            yield return new WaitForSeconds(10f);
            isStarSelected = false;
            uiManager.AssignRandomImageToTheBtnIngredient();
            uiManager.MakeButtonInteractive(true);
        }
    }

    void CheckIfTheRightIngredientWasCollected()
    {
        if(uiManager.IngredientToBePickedID == ingredientID || isStarSelected)
        {
            points.AddPoints(1);
        }
        else
        {
            points.TakePoints(2);
        }
    }
}
