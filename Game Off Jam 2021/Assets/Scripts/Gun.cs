using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int doDamage;
    public int damage;
    public float bulletSpeed;
    public float range;
    public float fireRate;

    

    public float reloadTime;
    private float nextTimeToFire = 0f;
    

    public int currentMagCapacity;
    public int maxMagCapacity;
    public int maxStorageCapacity;

    private bool isReloading = false;

    public Transform[] shotPoints;
    public GameObject bulletPrefab;
    private float offset;


    
    void Start()
    {
        damage = doDamage;
        maxMagCapacity = currentMagCapacity;
    }

    // Update is called once per frame
    void Update() 
    {
        if(isReloading && maxStorageCapacity > 0)
        {
            return;
        }
        
        if(currentMagCapacity <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            
            Shoot();
            nextTimeToFire = Time.time + 1f/fireRate;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        //TODO: Play Animation
        //TODO: Spawn Particles
        //TODO: Play Sound
        if(currentMagCapacity > 0)
        {
            for (int i = 0; i < shotPoints.Length; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, shotPoints[i].position, shotPoints[i].rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shotPoints[i].right * bulletSpeed, ForceMode2D.Impulse);
            }
            

            currentMagCapacity--;
        }
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        if(currentMagCapacity != maxMagCapacity && maxStorageCapacity > 0)
        {
            int ammoRestore = maxMagCapacity - currentMagCapacity;

            if(maxStorageCapacity >= ammoRestore)
            {
                currentMagCapacity += ammoRestore;
                maxStorageCapacity -= ammoRestore;
            }
            if(ammoRestore > maxStorageCapacity)
            {
                maxStorageCapacity = 0;
                currentMagCapacity += ammoRestore;
            }
            
            
        }
        isReloading = false;
    }
}
