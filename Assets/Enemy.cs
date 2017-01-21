using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject player;
    Transform playerT;
    float speed = 5f;
    bool moveTowardPlayer = false;
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
        
        if (moveTowardPlayer == true)
        {
            MoveTowardPlayer();
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Yay Collided");
            moveTowardPlayer = true;
               
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveTowardPlayer = false;
        }
    }

    void MoveTowardPlayer()
    {
        
        if (Vector2.Distance(transform.position, playerT.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, speed * Time.deltaTime);
        }
       
    }
}
