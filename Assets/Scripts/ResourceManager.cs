using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	public PlantItem plantItem;
	// Start is called before the first frame update
	void Start()
	{
		List<GamePlant> plants = new List<GamePlant>();
		var resources = Resources.LoadAll("Plants", typeof(GamePlant));

		foreach (var resource in resources)
		{
			GamePlant plant = Instantiate((GamePlant)resource);
			plants.Add(plant);
		}

		// Sort by buy price
		plants.Sort((item1, item2) => item1.buyPrice.CompareTo(item2.buyPrice));
		plants.ForEach(plant =>
		{
			PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
			newPlant.plant = plant;
		});
	}
}
