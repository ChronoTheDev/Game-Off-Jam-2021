using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Object", menuName = "Inventory System/Items/Gun")]
public class GunObject : ItemObject
{
    
    private void Awake() 
    {
        type = ItemType.Gun;

    }
}
