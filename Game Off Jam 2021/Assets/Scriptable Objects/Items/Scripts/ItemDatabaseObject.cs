using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] itemObjects;
    

    public void UpdateID()
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if(itemObjects[i].data.id != i)
        {
            itemObjects[i].data.id = i;
        }
        }
        
    }
    public void OnAfterDeserialize()
    {
        
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
        
    }
}
