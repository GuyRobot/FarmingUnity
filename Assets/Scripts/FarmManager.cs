using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
	public int money = 100;
	// Whether is plating plant or not - set when user buy plant for planting
	[HideInInspector]
	public bool isPlanting = false;
	// The plant item the user had bought for planting
	[HideInInspector]
	public PlantItem selectedPlant;

	public Color buyActiveColor = Color.green;
	public Color buyInactiveColor = Color.red;
	public string buyActiveText = "Buy";
	public string buyInactiveText = "Cancel";

	private UIManager uIManager;
	// Start is called before the first frame update
	void Start()
	{
		uIManager = FindAnyObjectByType<UIManager>();
	}

	// Update is called once per frame
	public void SelectPlant(PlantItem plant)
	{
		if (selectedPlant == plant)
		{
			selectedPlant.Deactivate();
			selectedPlant = null;
			isPlanting = false;
		}
		else
		{
			if (selectedPlant != null)
			{
				selectedPlant.Deactivate();
			}
			selectedPlant = plant;
			isPlanting = true;

			selectedPlant.Activate();
		}
	}

	public bool Transact(int amount)
	{
		if (money + amount < 0) return false;
		money += amount;
		uIManager.UpdateUI();
		return true;
	}
}
