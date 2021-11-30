using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public InventoryObject inventory;
    public InventoryObject equipment;

    private Transform gun;
    private Transform grenade;
    private Transform melee;
    public Transform weaponPosition;

    public Animator anim;

    public Attribute[] attributes;

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth =  maxHealth;

        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnRemoveItem;
            equipment.GetSlots[i].OnAfterUpdate += OnAddItem;
        }
    }

    public void OnRemoveItem(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
            break;
            case InterfaceType.Equipment:
            
            for (int i = 0; i  < _slot.item.buffs.Length; i++)
            {
                for (int j = 0; j < attributes.Length; j++)
                {
                    if(attributes[j].type == _slot.item.buffs[i].attribute)
                    {
                        attributes[j].value.RemoveModifier(_slot.item.buffs[i]);
                    }
                }
            }
            
            if(_slot.ItemObject.characterDisplay != null)
            {
                switch (_slot.allowedItems[0])
                {
                    case ItemType.Gun:
                    Destroy(gun.gameObject);
                    break;

                    case ItemType.Melee:
                    Destroy(melee.gameObject);
                    break;

                    case ItemType.Grenade:
                    Destroy(grenade.gameObject);
                    break;
                    
                }
            }
            break;
            
        }
    }
    public void OnAddItem(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
        {
            return;
        }
        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
            
            break;
            case InterfaceType.Equipment:
            for (int i = 0; i  < _slot.item.buffs.Length; i++)
            {
                for (int j = 0; j < attributes.Length; j++)
                {
                    if(attributes[j].type == _slot.item.buffs[i].attribute)
                    {
                        attributes[j].value.AddModifier(_slot.item.buffs[i]);
                    }
                }
            }
            
            if(_slot.ItemObject.characterDisplay != null)
            {
                switch (_slot.allowedItems[0])
                {
                    case ItemType.Gun:
                    gun = Instantiate(_slot.ItemObject.characterDisplay, weaponPosition).transform;
                    break;

                    case ItemType.Melee:
                    melee = Instantiate(_slot.ItemObject.characterDisplay, weaponPosition).transform;
                    break;

                    case ItemType.Grenade:
                    grenade = Instantiate(_slot.ItemObject.characterDisplay, weaponPosition).transform;
                    break;
                    
                }
            }
            break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            equipment.Save();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            inventory.Load();
            equipment.Load();
            
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        FindObjectOfType<AudioManager>().Play("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("PlayerDead");
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {

            Item _item = new Item(item.item);
            if(inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }
             
            
        }
    }
    
    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated value is now " , attribute.value.ModifiedValue));
    }
    private void OnApplicationQuit() 
    {
        inventory.Clear();
        equipment.Clear();
    }
}
[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public ModifiableInt value;
    public void SetParent(Player _parent)
    {   
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
