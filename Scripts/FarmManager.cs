using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;

    public int money = 100;
    public TextMeshProUGUI moneyTxt;

    public int harvestedPlantCount = 0;
    public TextMeshProUGUI harvestedTxt;

    public int availablePlotCount = 4; // Set the initial number of available plots
    public TextMeshProUGUI availablePlotTxt;


    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;


    public bool isSelecting = false;
    public int selectedTool = 0;

    // 1-water 2-fertillizer 3-buy plot

    public Image[] buttonImg;
    public Sprite normalButton;
    public Sprite selectedButton;


    void Start()
    {
        moneyTxt.text = "$" + money;
        harvestedTxt.text = "Harvested: " + harvestedPlantCount;
        availablePlotTxt.text = "Available Plots: " + availablePlotCount;
    }

    public int GetHarvestedPlantCount()
    {
        return harvestedPlantCount;
    }

    // Method to increment the harvested plant count
    public void IncrementHarvestedPlantCount()
    {
        harvestedPlantCount++;
        harvestedTxt.text = "Harvested: " + harvestedPlantCount;
    }

    public void IncrementAvailablePlotCount()
    {
        availablePlotCount++;
        availablePlotTxt.text = "Available Plots: " + availablePlotCount;
    }

    public void SelectPlant(PlantItem newPlant) 

    {
        if (selectPlant == newPlant)
        {
            CheckSelection();
            
        }
        else
        {
            CheckSelection();
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "Cancel";
            Debug.Log("Selected " + selectPlant.plant.plantName);
            isPlanting = true;

        }


    }

    public void SelectTool(int toolNumber)
    {
        if(toolNumber == selectedTool)
        {
            //deselect
            CheckSelection();
        }
        else
        {
            //select tool number and check to see if any was also selected
            CheckSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonImg[toolNumber - 1].sprite = selectedButton;
        }
    }


    void CheckSelection()
    {
        if (isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "Buy";
                selectPlant = null; 
            }
        }
        if (isSelecting)
        {
            if(selectedTool > 0)
            {
                buttonImg[selectedTool - 1].sprite = normalButton;
            }
            isSelecting = false;
            selectedTool = 0;
        }
    }
    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }

    // Add method to count the number of harvestable plants
 
}
