using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public static int doDamage;
    public int damage;
    public int maxHealth;
    public int currentHealth;

    public float moveSpeed;

    public float timeBtwShots;
    private float nextShotTime;

    public float minDist;

    public Transform target;
    public GameObject projectile;
    public GameObject effect;
    


    // Start is called before the first frame update
    void Start()
    {
        currentHealth =  maxHealth;
        doDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
       
                
        
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("EnemyDead");
        Destroy(gameObject);
    }

    public void Attack()
    {
        if(Time.time >= nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("EnemyShoot");
            nextShotTime = Time.time + timeBtwShots;
        }
       
    }

    public void Follow()
    {
        if(Vector2.Distance(transform.position, target.position) > minDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        
    }

    
}
