using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopSystem : MonoBehaviour
{
	#region Singleton

	public static ShopSystem instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Shop System found!");
			return;
		}

		instance = this;
	}

	#endregion

	public GameObject ShopPanel;
	public TextMeshProUGUI moneyText;
	public int totalMoney;

	void Update()
	{
		moneyText.text = "$" + totalMoney.ToString();

		if (Input.GetButtonDown("Shop"))
		{
			ShopPanel.SetActive(!ShopPanel.activeSelf);
			
		}
	}
}
