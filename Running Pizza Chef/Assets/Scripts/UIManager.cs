using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image imgIngredient;
    [SerializeField] Text txtHighScore;
    [SerializeField] Sprite spriteStar;

    MovePlayer movePlayerScript;
    Points points;
    int ingredientToBePickedID;
    public int IngredientToBePickedID { get { return ingredientToBePickedID; } }
    void Start()
    {
        points = FindObjectOfType<Points>();
        movePlayerScript = FindObjectOfType<MovePlayer>();
        AssignRandomImageToTheBtnIngredient();
        if (points)
        {
            txtHighScore.text = points.GetHighScore().ToString();
        }
    }

    void Update()
    {
        
    }

    public void AssignStarImage()
    {
        imgIngredient.sprite = spriteStar;
       
    }

    public void MakeButtonInteractive(bool isInteractive)
    {
        imgIngredient.transform.GetComponentInParent<Button>().interactable = isInteractive;
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
