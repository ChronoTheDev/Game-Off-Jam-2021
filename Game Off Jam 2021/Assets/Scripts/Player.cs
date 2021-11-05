using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public InventoryObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth =  maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit() 
    {
        inventory.Container.Clear();
    }
}
