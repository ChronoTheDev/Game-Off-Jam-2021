using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position == target)
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if(other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(Enemy.doDamage);
        }
    }

    void DestroyBullet()
    {
        //TODO: Play some particles
        Destroy(gameObject);
    }
}
