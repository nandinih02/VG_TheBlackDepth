using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float delay = 0.3f;
         
    private Rigidbody2D rbody2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            //move right
            rbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rbody2D.velocity = new Vector2(-moveSpeed, 0f);
            //move right
        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        //flip sprite
        transform.localScale = new Vector2(-(Mathf.Sign(rbody2D.velocity.x)), transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            animator.SetBool("hitByBullet", true);
            Destroy(this.gameObject,delay);
            
        }
    }
}
