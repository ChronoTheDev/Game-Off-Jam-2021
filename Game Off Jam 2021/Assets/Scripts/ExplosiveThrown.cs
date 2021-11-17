using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveThrown : MonoBehaviour
{
    public float throwSpeed;

    public Transform throwPoint;
    public GameObject explosivePrefab;
    public GameObject explodedPrefab;

   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameObject explosive = Instantiate(explosivePrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody2D rb = explosive.GetComponent<Rigidbody2D>();
            rb.AddForce(throwPoint.right * throwSpeed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        print(gameObject.tag);
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            Instantiate(explosivePrefab, transform.position, transform.rotation);
        }
    }

    
}
