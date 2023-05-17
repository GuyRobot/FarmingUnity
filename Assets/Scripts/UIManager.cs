using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI storeTitleTxt;
	public TextMeshProUGUI storeMoneyTxt;

	public string storeTitle;

	public Button wateringBtn;
	public Button ferterlizingBtn;
	public Button plotingBtn;

	public Sprite selectedBtnSprite;
	public Sprite btnSprite;

	FarmManager farmManager;
	// Start is called before the first frame update
	void Start()
	{
		farmManager = FindAnyObjectByType<FarmManager>();
		UpdateUI();
	}

	public void UpdateUI()
	{
		storeTitleTxt.text = storeTitle;
		storeMoneyTxt.text = string.Format("{0:C0}", farmManager.money);
	}

	public void UpdatePlantingModeUI(PlantingMode plantingMode)
	{
		// Reset tool state and update individual tool separately
		ResetPlantingToolBtnState();

		if (plantingMode == PlantingMode.Watering)
		{
			wateringBtn.image.sprite = selectedBtnSprite;
			return;
		}

		if (plantingMode == PlantingMode.Ferterlizing)
		{
			ferterlizingBtn.image.sprite = selectedBtnSprite;
			return;
		}

		if (plantingMode == PlantingMode.Ploting)
		{
			plotingBtn.image.sprite = selectedBtnSprite;
			return;
		}

		if (plantingMode == PlantingMode.Planting)
		{
			farmManager.selectedPlant?.Activate();
		}

		// Need to clear selected plant when not planting to avoid select plant item that previously being cleared
		// by other planting mode still the same, thus cause it still not planting
		if (plantingMode != PlantingMode.Planting)
		{
			farmManager.selectedPlant = null;
		}
	}

	public void ResetPlantingToolBtnState()
	{
		farmManager.selectedPlant?.Deactivate();
		wateringBtn.image.sprite = btnSprite;
		ferterlizingBtn.image.sprite = btnSprite;
		plotingBtn.image.sprite = btnSprite;
	}

}
