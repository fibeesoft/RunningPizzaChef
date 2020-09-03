using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Button btnIngredient;

    int ingredientToBePickedID;
    public int IngredientToBePickedID { get { return ingredientToBePickedID; } }
    void Start()
    {
        AssignRandomImageToTheBtnIngredient();
    }

    void Update()
    {
        
    }

    public void AssignRandomImageToTheBtnIngredient()
    {
        int rand = Random.Range(0, gameManager.ingredients.Length);
        ingredientToBePickedID = rand;
        btnIngredient.GetComponent<Image>().sprite = gameManager.ingredients[rand];
    }
}
