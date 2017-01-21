using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject player;
    Transform playerT;
    float speed = 5f;
    bool moveTowardPlayer = false;
    bool shootAtPlayer = false;
    float timer = 1.5f;

    public GameObject bullet;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        playerT = player.GetComponent<Transform>();

        if (player == null)
        {
            Debug.LogError("Player is Null");
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (moveTowardPlayer)
        {
            MoveTowardPlayer();

        }

        if (shootAtPlayer)
        {
            Shoot();
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
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 2;
        }
    }

}
