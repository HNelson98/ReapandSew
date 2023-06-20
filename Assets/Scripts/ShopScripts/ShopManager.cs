using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int gold;
    public TMP_Text goldUI;
    public ShopItemSO[] ShopItemSO;
    public ShopTemplate[] shopPanels; 
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ShopItemSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        goldUI.text = "Gold: " + gold.ToString();
        LoadPanels();
        CheckPurchasable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addGold() //simple script to add gold 
    {
        gold = gold + 10;
        goldUI.text = "Gold: " + gold.ToString();
        CheckPurchasable();
    }

    public void LoadPanels()
    {
        for(int i = 0; i < ShopItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = ShopItemSO[i].title;
            shopPanels[i].descTxt.text = ShopItemSO[i].desc;
            shopPanels[i].costTxt.text = ShopItemSO[i].baseCost.ToString();

        };
    }

    public void CheckPurchasable()
    {
        for(int i = 0; i < ShopItemSO.Length; i++)
            {
                if (gold >= ShopItemSO[i].baseCost) // if I have enough gold
                    myPurchaseBtns[i].interactable = true;
                else
                    myPurchaseBtns[i].interactable = false;
                
                
            }
    }

    public void PurchaseItem(int btnNum)
    {
        if (gold >= ShopItemSO[btnNum].baseCost)
        {
            gold = gold - ShopItemSO[btnNum].baseCost;
            goldUI.text = "Gold: " + gold.ToString();
            CheckPurchasable();

        }
    }


}
