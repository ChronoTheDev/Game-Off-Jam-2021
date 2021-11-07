using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : UserInterface
{
    public int x_Start;
    public int y_Start;
    public int x_SpaceBtwItem;
    public int numOfColumn;
    public int y_SpaceBtwItem;

    public GameObject inventoryPrefab;

    public override void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, -Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);


            AddEvent(obj, EventTriggerType.PointerEnter, delegate {OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate {OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate {OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate {OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate {OnDrag(obj); });
            itemsDisplayed.Add(obj, inventory.Container.Items[i]);
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(x_Start + (x_SpaceBtwItem * (i % numOfColumn)), y_Start + (-y_SpaceBtwItem * (i/numOfColumn)), 0f);
    }

}
