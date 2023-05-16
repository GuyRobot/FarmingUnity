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

}
