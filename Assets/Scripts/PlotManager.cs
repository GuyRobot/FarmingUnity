using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
	bool isPlanted = false;
	SpriteRenderer plant;
	SpriteRenderer plot;
	BoxCollider2D plantCollider;
	GamePlant gamePlant;

	int plantStage = 0;
	float timer = 0;

	// Farm manager for plating plant
	FarmManager farmManager;

	// State color indicate can plant or not
    public Color plantableColor = Color.green;
    public Color unPlantableColor = Color.red;
	// Start is called before the first frame update
	void Start()
	{
		plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
		plot = GetComponent<SpriteRenderer>();
		plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();

		farmManager = FindAnyObjectByType<FarmManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (isPlanted)
		{
			timer -= Time.deltaTime;
			if (timer < 0 && plantStage < gamePlant.plantStages.Length - 1)
			{
				timer = gamePlant.timeGrowth;
				plantStage++;
				UpdateStage();
			}
		}
	}

	private void OnMouseDown()
	{
		if (isPlanted)
		{
			if (plantStage == gamePlant.plantStages.Length - 1)
			{
				Harvest();
			}
		}
		else if (farmManager.isPlanting)
		{
			Plant(farmManager.selectedPlant.plant);
		}
	}

	private void OnMouseOver()
	{
		if (!farmManager.isPlanting) return;
		if (farmManager.money >= farmManager.selectedPlant.plant.buyPrice && !isPlanted)
		{
			plot.color = plantableColor;
		}
		else
		{
			plot.color = unPlantableColor;
		}
	}

	private void OnMouseExit()
	{
		if (!farmManager.isPlanting) return;
		plot.color = Color.white;
	}

	void Harvest()
	{
		Debug.Log("Harvest");
		farmManager.Transact(gamePlant.sellPrice);
		isPlanted = false;
		plantStage = 0;
		UpdateStage();
		plant.gameObject.SetActive(false);
	}

	void Plant(GamePlant gamePlant)
	{
		if (!farmManager.Transact(-gamePlant.buyPrice)) return;
		this.gamePlant = gamePlant;
		Debug.Log("Plant");
		isPlanted = true;
		timer = gamePlant.timeGrowth;
		UpdateStage();
		plant.gameObject.SetActive(true);
	}

	void UpdateStage()
	{
		plant.sprite = gamePlant.plantStages[plantStage];
		plantCollider.size = plant.sprite.bounds.size;
		plantCollider.offset = new Vector2(0, plant.sprite.bounds.size.y / 2);
	}
}
