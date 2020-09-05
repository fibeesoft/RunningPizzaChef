using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    GameManager gameManager;
    Animator anim;
    int ingredientID;
    public int IngredientID { get { return ingredientID; } }
    void Start()
    {
        InitializeIngredient();
    }

    private void OnEnable()
    {
        InitializeIngredient();
    }


    void InitializeIngredient()
    {
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        AssignRandomIDAndImage();
    }
    void AssignRandomIDAndImage()
    {
        int rand = Random.Range(0, gameManager.ingredients.Length);
        ingredientID = rand;
        GetComponent<SpriteRenderer>().sprite = gameManager.ingredients[rand];
    }

    public void SwitchCollectAnimation()
    {
        anim.SetTrigger("Collect");
        StartCoroutine(DisableAfterDelay(1f));
    }

    IEnumerator DisableAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

}
