using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;
    private bool dragSingle;

    private Slot_UI draggedSlot;
    private Image draggedIcon;

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        Refresh();
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
    }

    public void ToggleInventory()
    {
        if(InventoryPanel != null)
        {
            if(!InventoryPanel.activeSelf)
            {
                InventoryPanel.SetActive(true);
                Refresh();
            }
            else
            {
                InventoryPanel.SetActive(false);
            }
        }
    } 
    
    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                    
                }
            }
        }
        else if(slots.Count == player.toolbar.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.toolbar.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.toolbar.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                    
                }
            }
        }
    }

    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
            player.inventory.slots[draggedSlot.slotID].itemName);

        if(itemToDrop != null)
        {
            if(dragSingle == true)
            {
                player.DropItem(itemToDrop);
                player.inventory.Remove(draggedSlot.slotID);
            }
            else
            {
                player.DropItem(itemToDrop, player.inventory.slots[draggedSlot.slotID].count);
                player.inventory.Remove(draggedSlot.slotID, 
                    player.inventory.slots[draggedSlot.slotID].count);
            }
            Refresh();
        }
        
        draggedSlot = null;
    }
    
    public void SlotBeginDrag(Slot_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(50,50);

        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Start Drag: " + draggedSlot.name);
    }

    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Dragging: " + draggedSlot.name);

    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;
        Debug.Log("Done Drag: " + draggedSlot.name);

    }

    public void SlotDrop(Slot_UI slot)
    {
        Debug.Log("Dropped : " + draggedSlot.name + " on " + slot.name);

    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas)
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (canvas.transform as RectTransform, Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }
}
