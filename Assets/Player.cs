using UnityEngine;
using System.Collections;

public class Player : Character {
    Vector3 directionVector;
    Vector3 targetVector;

    bool spaceDown = false;
    bool jumping = false;
    bool canJump = true;

    public float jumpSpeed = 15.0f;
    public float jumpHeightMax = 5.5f;
	private float jumpHeight;

	private Animator animator;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        speed = 7.5f;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        HorizontalMovement(Movement());
	}

    private Vector2 Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            directionVector = Vector3.left * speed * Time.smoothDeltaTime;
			if (spriteRenderer.flipX)
			{
				spriteRenderer.flipX = false;
			}
        }
        else if (Input.GetKey(KeyCode.D))
        {
            directionVector = Vector3.right * speed * Time.smoothDeltaTime;
			if (!spriteRenderer.flipX)
			{
				spriteRenderer.flipX = true;
			}
		}
        else
        {
            directionVector = Vector3.zero * speed * Time.smoothDeltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !spaceDown && canJump)
        {
            jumpHeight = jumpHeightMax + transform.position.y;
            spaceDown = true;
            jumping = true;
            canJump = false;
			animator.SetTrigger("playerJump");
		}
        if(Input.GetKeyDown(KeyCode.Space) && spaceDown)
        {
            spaceDown = false;
        }
        if(jumping)
        {

            if (transform.position.y <= jumpHeight)
            {
                directionVector = new Vector3(directionVector.x, jumpSpeed * Time.smoothDeltaTime, 0);
            }
            else
            {
                jumping = false;
            }
        }

        return directionVector;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "floor")
        {
            jumping = false;
            canJump = true;
        }
    }
}
