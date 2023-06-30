using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            InventoryPanel.SetActive(false);
        }
    } 
    
    public void Setup()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
