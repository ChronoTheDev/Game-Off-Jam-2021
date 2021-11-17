using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float range;
    
    private float totalDistance;
    private Vector3 lastPos;

    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
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

    // void OnTriggerEnter2D(Collider2D other) 
    // {
            
            
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         //Let enemy take damage
    //         DestroyBullet();
    //     }
    // }
    

    void DestroyBullet()
    {
        //TODO: Play some particles
        Destroy(gameObject);
    }
}
