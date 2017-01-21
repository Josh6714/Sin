using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    protected float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void HorizontalMovement(Vector3 vector)
    {
        if(vector.x != 0 || vector.y != 0)
        {
            //transform.GetComponent<Rigidbody2D>().AddForce(vector, ForceMode2D.Impulse);
            transform.position += vector;
        }
        else
        {
            //transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    protected void Jump()
    {

    }
}
