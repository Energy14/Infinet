using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ResourceItem
{
    public string name;
    public Sprite sprite;
}
[System.Serializable]
public class RecipeItem
{
    public List<string> resources;
    public string result;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<ResourceItem> itemList;
    public List<RecipeItem> recipeList;

    public DropObject firstDrop;
    public ResultObject resultObject;
    public GameObject resultObj;
    public Image resultImage;
    public GameObject buttonCollect;
    public ParticleSystem mergeParticles;
    public GameObject tutorial;
    public GameObject stageCompleted;
    public Text timeObject;
    public AudioClip mergeSound;
    public AudioSource audioSource;

    public MainCanvas canvas;

    private int i;

    private string timeNumber;

    internal readonly List<string> currentRecipe = new List<string>();

    private void Awake()
    {
        instance = this;
        buttonCollect.SetActive(false);
        tutorial.SetActive(true);
        audioSource.clip = mergeSound;
    }

    public void clearRecipe()
    {
        Debug.Log("Clear recipe");
        currentRecipe.Clear();
        firstDrop.itemName = "";
        canvas.clearSlots();
        canvas.disableSlots();
        resultObj.SetActive(false);
        resultObject.image.sprite = null;
    }

    public void AddItem(string item)
    {
        currentRecipe.Add(item);
        CheckRecipe();
    }

    public void RemoveItem(string item)
    {
        currentRecipe.Remove(item);
    }

    public void CheckRecipe()
    {
        if (currentRecipe.Count < 2)
        {
            return;
        }
        bool found = false;
        RecipeItem result = null;
        i = 0;
        foreach (RecipeItem recipe in recipeList)
        {
            if (recipe.resources.Count != currentRecipe.Count)
            {
                Debug.Log("Current recipe item count: " + currentRecipe.Count.ToString());
                continue;
            }
            foreach (string itm in currentRecipe)
            {
                if (recipe.resources.IndexOf(itm) < 0)
                {
                    found = false;
                    break;
                } else
                {
                    found = true;
                }
            }
            if (found)
            {
                result = recipe;
                break;
            }
            i++;
        }
        if (!found)
        {
            return;
        }

        //TODO make new recipe item
        Debug.Log("Recipe found: " + result.result);

        mergeParticles.Play();
        audioSource.Play();

        ResourceItem rItem = itemList.Find((item) => item.name == result.result);
        if (rItem == null)
            return;
        canvas.disableSlots();
        resultObj.SetActive(true);
        resultObject.itemName = rItem.name;
        resultObject.image.sprite = rItem.sprite;
        buttonCollect.SetActive(true);

        if (rItem.name == "The Earth")
        {
            buttonCollect.SetActive(false);
            stageCompleted.SetActive(true);
        }
        switch (rItem.name)
        {
            case "Proton":
                timeNumber = "9750000000";
                break;
            case "Hydrogen":
                timeNumber = "7324500000";
                break;
            case "The Sun":
                timeNumber = "4600000000";
                break;
            case "Young Earth":
                timeNumber = "4540000000";
                break;
            case "The Earth":
                timeNumber = "3500000000";
                break;
        }
        timeObject.text = timeNumber + " years ago";
    }
    public void hideTutorial()
    {
        tutorial.SetActive(false);
    }
    public void secondStage()
    {
        SceneManager.LoadScene("SecondStage");
    }
}
