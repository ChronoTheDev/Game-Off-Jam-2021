using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grenade Object", menuName = "Inventory System/Items/Grenade")]
public class GrenadeObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Grenade;
    }
}
