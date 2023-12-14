using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject plantItem;
    List<PlantObject> plantObjects = new List<PlantObject>(); 

    private void Awake()
    {
        //Asset/Resources/Plant
        var loadPlants = Resources.LoadAll("Plant", typeof(PlantObject));
        foreach (var plant in loadPlants)
        {
            plantObjects.Add((PlantObject)plant);

           
        }
        plantObjects.Sort(SortByPrice);

        foreach (var plant in plantObjects)
        {
            PlantItem newplant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
            newplant.plant = plant;
        }
    }
    int SortByPrice(PlantObject plantOblect1, PlantObject plantObject2)
    {
        return plantOblect1.buyPrice.CompareTo(plantObject2.buyPrice);
    }

    int SortByTime(PlantObject plantOblect1, PlantObject plantObject2)
    {
        return plantOblect1.timeBtwStages.CompareTo(plantObject2.timeBtwStages);
    }
}
