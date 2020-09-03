using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    GameManager gameManager;
    int ingredientID;
    public int IngredientID { get { return ingredientID; } }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        AssignRandomIDAndImage();
    }

    void Update()
    {
        
    }

    void AssignRandomIDAndImage()
    {
        int rand = Random.Range(0, gameManager.ingredients.Length);
        ingredientID = rand;
        GetComponent<SpriteRenderer>().sprite = gameManager.ingredients[rand];
    }

}
