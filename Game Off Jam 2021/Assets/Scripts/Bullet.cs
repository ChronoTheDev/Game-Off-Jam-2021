using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float range;
    
    private float totalDistance;
    private Vector3 lastPos;

    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        Physics.IgnoreLayerCollision(6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(lastPos, transform.position);
        totalDistance += distance;
        lastPos = transform.position;

        if(totalDistance > range || totalDistance < -range )
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
        Enemy enemy = other.GetComponent<Enemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(Gun.doDamage);
            DestroyBullet();
        }
        
    }
    

    void DestroyBullet()
    {
        
        FindObjectOfType<AudioManager>().Play("Bullet_HitWall");
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
