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
    public Button buyButton;

    FarmManager farmManager;
    // Start is called before the first frame update
    void Start()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = string.Format("{0:C0}", plant.buyPrice);
        icon.sprite = plant.icon;

        farmManager = FindAnyObjectByType<FarmManager>();
        buyButton.image.color = farmManager.buyActiveColor;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = farmManager.buyActiveText;
    }

    public void BuyPlant()
    {
        Debug.Log("Buy");
        farmManager.SelectPlant(this);
    }

    public void Deactivate()
    {
		buyButton.image.color = farmManager.buyActiveColor;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = farmManager.buyActiveText;
    }

    public void Activate()
    {
		buyButton.image.color = farmManager.buyInactiveColor;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = farmManager.buyInactiveText;
    }
}
