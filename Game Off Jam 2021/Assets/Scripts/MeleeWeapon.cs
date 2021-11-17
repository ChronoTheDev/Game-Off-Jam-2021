using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage;
    public float attackRange;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("Fire1"))
        {
            Attack();
        }
    }
    
    void Attack()
    {
        //Todo : Make Animation
    }
}
