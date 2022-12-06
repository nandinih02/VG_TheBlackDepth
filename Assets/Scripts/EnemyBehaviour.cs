using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float delay = 0.3f;
    public GameObject scoreGO;
    public ScoreController scoreController;
    public bool chasePlayer=false;
    public float detectionRange=20f;
    GameObject player;


    private Rigidbody2D rbody2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scoreGO = GameObject.Find("ScoreController");
        player = GameObject.Find("Player");
      //  scoreController = scoreGO.GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < detectionRange && chasePlayer==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * (moveSpeed*2f));
        }
        else
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
        //transform.localScale = new Vector3(Mathf.Abs(rbody2D.velocity.x),transform.localScale.y,transform.localScale.z);
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
            LivesStatic.score += 10;

        }
    }
}
