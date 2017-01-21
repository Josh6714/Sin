using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    float distance;
    Transform PlayerT;
    Vector3 speed;
	// Use this for initialization
	void Start () {

        GameObject player = GameObject.FindWithTag("Player");
        PlayerT = player.GetComponent<Transform>();
        distance = PlayerT.position.x - transform.position.x;
        speed = Vector3.Normalize(PlayerT.position - transform.position) * 5;
        transform.right = PlayerT.position - transform.position;



    }
	
	// Update is called once per frame
	void Update () {


        transform.position += speed * Time.deltaTime;
        //if (distance > 0)
        //{
        //    transform.position += speed * Time.deltaTime;
        //}
        //else
        //{
        //    transform.position -= new Vector3(5, 0) * Time.deltaTime;
        //}
        
		
	}
}
