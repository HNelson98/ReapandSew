using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Object/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string desc;
    public int baseCost;
}
