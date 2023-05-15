using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class GamePlant : ScriptableObject
{
	public Sprite[] plantStages;
	public float timeGrowth;
	public string plantName;
	public int price;
	public Sprite icon;
}
