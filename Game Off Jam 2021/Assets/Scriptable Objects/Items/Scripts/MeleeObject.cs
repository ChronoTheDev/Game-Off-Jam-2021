using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Object", menuName = "Inventory System/Items/Melee")]
public class MeleeObject : ItemObject
{

    private void Awake() 
    {
        type = ItemType.Melee;

    }
}
