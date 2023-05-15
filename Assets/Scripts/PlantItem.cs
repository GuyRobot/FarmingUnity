using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public GamePlant plant;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI priceTxt;
    public Image icon;

    FarmManager farmManager;
    // Start is called before the first frame update
    void Start()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = string.Format("{0:C0}", plant.price);
        icon.sprite = plant.icon;

        farmManager = FindAnyObjectByType<FarmManager>();
    }

    public void BuyPlant()
    {
        Debug.Log("Buy");
        farmManager.SelectPlant(this);
    }
}
