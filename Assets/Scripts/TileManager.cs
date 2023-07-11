using System.Net.Sockets;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap IntractableMap;

    [SerializeField] private Tile hiddenIntractableTile;
    void Start()
    {
        foreach (var position in IntractableMap.cellBounds.allPositionsWithin)
        {
            IntractableMap.SetTile(position, hiddenIntractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = IntractableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }

        return false;
    }

    
}
