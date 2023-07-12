using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Inventory inventory;
   public Inventory toolbar;

   private void Awake()
   {
      inventory = new Inventory(27);
      toolbar = new Inventory(9);
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.Space))
      {
         Vector3Int position = new Vector3Int((int)transform.position.x,
            (int)transform.position.y, 0);
         Debug.Log(position);   
         if(GameManager.instance.tileManager.IsInteractable(position))
         {
            Debug.Log("Tile is Interacable");
            GameManager.instance.tileManager.SetInteracted(position);
         }
      }
   }

   public void DropItem(Item item)
   {
      Vector2 spawnLocation = transform.position;

      Vector2 spawnOffset = Random.insideUnitCircle * 2f;

      Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

      droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);

      
   }

   public void DropItem(Item item, int qtyToDrop)
   {
      for(int i = 0; i< qtyToDrop; i++)
      {
         DropItem(item);
      }
   }
}
