using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Object", menuName = "Inventory System/Items/Gun")]
public class GunObject : ItemObject
{
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Shots fired");
        }
    }
}
