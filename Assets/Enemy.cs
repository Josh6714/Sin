using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    protected Player player;
    protected Transform playerTransform;
    protected float speed = 10f;
    bool shootAtPlayer = false;
    protected int localscaleflip;

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

	public GameObject bullet;
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsTag("attackState"))
		//{
		//	isAttacking = false;
		//	Shoot();
		//}

		//if (shootAtPlayer)
		//{
		//	// This needs to be called after the animation check of attack state.
		//	PrepareToShoot();
		//}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    else if (name == "Archer")
        //    {
        //        shootAtPlayer = true;
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    else if (name == "Archer")
        //    {
        //        shootAtPlayer = false;
        //    }
        //}
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

	private void PrepareToShoot()
	{
        //	timer -= Time.deltaTime;
        //	if (timer <= 0)
        //	{
        //		animator.SetTrigger("attack");
        //		isAttacking = true;
        //		timer = 2;
        //	}
    }

}
