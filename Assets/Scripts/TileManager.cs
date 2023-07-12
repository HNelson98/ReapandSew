using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap intractableMap;

    [SerializeField] private Tile hiddenIntractableTile;
    [SerializeField] private Tile interactedTile;
    void Start()
    {
        foreach (var position in intractableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = intractableMap.GetTile(position);
            
            if(tile != null && tile.name == "Interactable_Visible")
            {
                intractableMap.SetTile(position, hiddenIntractableTile);
            }
        }

    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = intractableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "interactable")
            {
                return true;
            }
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        intractableMap.SetTile(position, interactedTile);
    }
}
