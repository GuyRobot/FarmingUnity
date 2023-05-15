using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
	// Whether is plating plant or not - set when user buy plant for planting
	[HideInInspector]
	public bool isPlanting = false;
	// The plant item the user had bought for planting
	[HideInInspector]
	public PlantItem selectedPlant;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	public void SelectPlant(PlantItem plant)
	{
		if (selectedPlant == plant)
		{
			selectedPlant = null;
			isPlanting = false;
		}
		else
		{
			selectedPlant = plant;
			isPlanting = true;
		}
	}
}
