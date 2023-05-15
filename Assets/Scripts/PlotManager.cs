using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
	bool isPlanted = false;
	SpriteRenderer plant;
	BoxCollider2D plantCollider;
	public GamePlant gamePlant;

	int plantStage = 0;
	float timer = 0;
	// Start is called before the first frame update
	void Start()
	{
		plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
		plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
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
		else
		{
			Plant();
		}
	}

	void Harvest()
	{
		Debug.Log("Harvest");
		isPlanted = false;
		plantStage = 0;
		UpdateStage();
		plant.gameObject.SetActive(false);
	}

	void Plant()
	{
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
