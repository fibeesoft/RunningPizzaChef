using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    UIManager uiManager;
    Points points;
    int ingredientID;
    void Start()
    {
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
            Destroy(collision.gameObject);
            uiManager.AssignRandomImageToTheBtnIngredient();
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
