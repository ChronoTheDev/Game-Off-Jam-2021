using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{

    public ItemObject item;

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = item.uiIcon;
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
    }
}
