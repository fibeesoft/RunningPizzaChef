using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image imgIngredient;
    MovePlayer movePlayerScript;

    int ingredientToBePickedID;
    public int IngredientToBePickedID { get { return ingredientToBePickedID; } }
    void Start()
    {
        movePlayerScript = FindObjectOfType<MovePlayer>();
        AssignRandomImageToTheBtnIngredient();
    }

    void Update()
    {
        
    }

    public void AssignRandomImageToTheBtnIngredient()
    {
        int rand = Random.Range(0, gameManager.ingredients.Length);
        ingredientToBePickedID = rand;
        imgIngredient.sprite = gameManager.ingredients[rand];
    }

    public void AssignNextIngredient()
    {
        if(ingredientToBePickedID < gameManager.ingredients.Length - 1)
        {
            ingredientToBePickedID++;
        }
        else
        {
            ingredientToBePickedID = 0;
        }
        imgIngredient.sprite = gameManager.ingredients[ingredientToBePickedID];
    }

    public void TurnJumpingOn()
    {
        movePlayerScript.TurnJumpingOn();
    }
}
