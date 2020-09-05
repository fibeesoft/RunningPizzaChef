using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    UIManager uiManager;
    Points points;
    GameManager gameManager;
    int ingredientID;
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
            uiManager.AssignRandomImageToTheBtnIngredient();

        }

        if (collision.transform.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }

    void CheckIfTheRightIngredientWasCollected()
    {
        if(uiManager.IngredientToBePickedID == ingredientID)
        {
            points.AddPoints(1);
        }
        else
        {
            points.TakePoints(2);
        }
    }
}
