using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    UIManager uiManager;
    int ingredientID;
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
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
            print("ok");
        }
        else
        {
            print("nok");
        }
    }
}
