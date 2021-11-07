using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public InventoryObject inventory;

    public MouseItem mouseItem = new MouseItem();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth =  maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            inventory.Load();
            
        }
    }

    public void TakeDamage()
    {
        currentHealth = maxHealth;
        if(currentHealth <= 0)
        {

        }
    }

    void Die()
    {
        //Play death animation
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }
    
    private void OnApplicationQuit() 
    {
        inventory.Container.Items = new InventorySlot[30];
    }
}
