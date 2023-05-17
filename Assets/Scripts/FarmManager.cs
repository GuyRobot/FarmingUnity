using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum PlantingMode { Planting, Watering, Ferterlizing, Ploting, None };
public class FarmManager : MonoBehaviour
{
	public int money = 100;
	// Whether is plating plant or not - set when user buy plant for planting
	[HideInInspector]
	public bool isPlanting
	{
		get { return plantingMode == PlantingMode.Planting; }
	}

	public int MyProperty { get; set; }
	// The plant item the user had bought for planting
	[HideInInspector]
	public PlantItem selectedPlant;

	public Color buyActiveColor = Color.green;
	public Color buyInactiveColor = Color.red;
	public string buyActiveText = "Buy";
	public string buyInactiveText = "Cancel";

	private UIManager uIManager;
	// Start is called before the first frame update
	private PlantingMode _plantingMode = PlantingMode.None;
	private PlantingMode plantingMode
	{
		get { return _plantingMode; }
		set
		{
			_plantingMode = value;
			uIManager.UpdatePlantingModeUI(value);
		}
	}


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
			plantingMode = PlantingMode.None;
		}
		else
		{
			if (selectedPlant != null)
			{
				selectedPlant.Deactivate();
			}
			selectedPlant = plant;
			plantingMode = PlantingMode.Planting;
		}

	}

	public void SelectTool(PlantingToolComponent plantingTool)
	{
		var plantingMode = plantingTool.mode;
		// Select plating again so de activate the selected plant
		if (this.plantingMode == PlantingMode.Planting && selectedPlant != null)
		{
			selectedPlant.Deactivate();
			this.plantingMode = PlantingMode.None;
		}

		if (this.plantingMode == plantingMode)
		{
			uIManager.ResetPlantingToolBtnState();
			return;
		}

		this.plantingMode = plantingMode;
	}

	public bool Transact(int amount)
	{
		if (money + amount < 0) return false;
		money += amount;
		uIManager.UpdateUI();
		return true;
	}
}
