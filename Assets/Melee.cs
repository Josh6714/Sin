using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{
    
    bool moveTowardPlayer = false;
    private bool isAttacking = false;
    float timer = 0f;
    
    private Vector3 targetVector;
    

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerTransform = player.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            Debug.LogError("Player is Null");
        }
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerTransform.position.x > transform.position.x)
        //{
        //    if ((DefaultSpriteDirectionIsLeft && !spriteRenderer.flipX) || (!DefaultSpriteDirectionIsLeft && spriteRenderer.flipX))
        //    {
        //        spriteRenderer.flipX = DefaultSpriteDirectionIsLeft ? true : false;
        //    }
        //}
        //else if ((DefaultSpriteDirectionIsLeft && spriteRenderer.flipX) || (!DefaultSpriteDirectionIsLeft && !spriteRenderer.flipX))
        //{
        //    spriteRenderer.flipX = DefaultSpriteDirectionIsLeft ? false : true;
        //}


        if (moveTowardPlayer)
        {
            MoveTowardPlayer();
        }
    }

    void MoveTowardPlayer()
    {

        targetVector = playerTransform.position - transform.position;
        targetVector = Vector3.Normalize(targetVector);

        if (targetVector.x > 0)
        {
            transform.localScale = new Vector3(.75f, .75f, .75f);
        }
        else
        {
            transform.localScale = new Vector3(-.75f, .75f, .75f);
        }

        if (Vector2.Distance(playerTransform.position, transform.position) > 2.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }

    }

    void Attack()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int damage = Random.Range(25, 33);
            player.Health -= damage;

            timer = 1.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveTowardPlayer = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer = 0;
            moveTowardPlayer = false;
        }
    }
}
