using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool DefaultSpriteDirectionIsLeft = true;

    GameObject player;
    Transform playerT;
    float speed = 5f;
    bool moveTowardPlayer = false;
    bool shootAtPlayer = false;
	private bool isAttacking = false;
    float timer = 1.5f;
	private int localscaleflip;

	private Animator animator;
	private SpriteRenderer spriteRenderer;

	public GameObject bullet;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        playerT = player.GetComponent<Transform>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (player == null)
        {
            Debug.LogError("Player is Null");
        }

		localscaleflip = DefaultSpriteDirectionIsLeft ? 1 : -1;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerT.position.x > transform.position.x)
		{
			if ((DefaultSpriteDirectionIsLeft && !spriteRenderer.flipX) || (!DefaultSpriteDirectionIsLeft && spriteRenderer.flipX))
			{
				spriteRenderer.flipX = DefaultSpriteDirectionIsLeft ? true : false;
			}
		}
		else if ((DefaultSpriteDirectionIsLeft && spriteRenderer.flipX) || (!DefaultSpriteDirectionIsLeft && !spriteRenderer.flipX))
		{
			spriteRenderer.flipX = DefaultSpriteDirectionIsLeft ? false : true;
		}
		
		if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsTag("attackState"))
		{
			isAttacking = false;
			Shoot();
		}

		if (moveTowardPlayer)
		{
			MoveTowardPlayer();
		}

		if (shootAtPlayer)
		{
			// This needs to be called after the animation check of attack state.
			PrepareToShoot();
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (name == "Melee")
            {
                moveTowardPlayer = true;
            }
            else if (name == "Archer")
            {
                shootAtPlayer = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (name == "Melee")
            {
                moveTowardPlayer = false;
            }
            else if (name == "Archer")
            {
                shootAtPlayer = false;
            }
        }
    }

    void MoveTowardPlayer()
    {
        
        if (Vector2.Distance(transform.position, playerT.position) > 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, speed * Time.deltaTime);
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
            int damage = Random.Range(10, 16);
            Debug.Log(damage);

            timer = 1.5f; 
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

	private void PrepareToShoot()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			animator.SetTrigger("attack");
			isAttacking = true;
			timer = 2;
		}
	}

}
