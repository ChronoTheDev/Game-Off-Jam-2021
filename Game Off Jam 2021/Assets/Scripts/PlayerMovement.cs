using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    private Vector2 moveDir;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        
        
        
        if(moveDir.x == 0)
        {
            anim.SetBool("isWalking", false);

            if(moveDir.y == 0)
            {
                anim.SetBool("isWalking", false);
            }else
            {
                 anim.SetBool("isWalking", true);
            }
        }else
        {
            anim.SetBool("isWalking", true);
            
        }
        

        
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + moveDir.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
