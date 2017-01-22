using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {
    Camera cam;
    Transform camTrans;
    float camWidth;
    float camHeight;


    Vector3 directionVector;
    Vector3 targetVector;

    List<GameObject> enemies = new List<GameObject>();

    bool spaceDown = false;
    bool jumping = false;
    bool canJump = true;

    public float jumpSpeed = 15.0f;
    public float jumpHeightMax = 5.5f;
	private float jumpHeight;
    float health = 100f;

	private Animator animator;
	private SpriteRenderer spriteRenderer;
    Sprite sprite;
    private bool mouseClicked = false;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camTrans = cam.transform;
        camWidth = cam.pixelWidth / 100f;
        camHeight = cam.pixelHeight / 100f;

        speed = 7.5f;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
        HorizontalMovement(Movement());
        FollowCam();
	}

    private Vector2 Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            directionVector = Vector3.left * speed * Time.smoothDeltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            directionVector = Vector3.right * speed * Time.smoothDeltaTime;
            transform.localScale = new Vector3(1, 1, 1);
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

        if(Input.GetMouseButtonDown(0) && !mouseClicked && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false)
        {

            animator.SetTrigger("playerAttack");

            
            mouseClicked = true;
        }
        else if(Input.GetMouseButtonUp(0) && mouseClicked)
        {
            mouseClicked = false;
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

    public void FollowCam()
    {
        if (transform.position.x > camTrans.position.x + ((camWidth - sprite.bounds.extents.x) / 2))
        {
            camTrans.position += new Vector3(directionVector.x, 0f, 0f);
        }
        else if(transform.position.x < camTrans.position.x - ((camWidth - sprite.bounds.extents.x) / 2))
        {
            camTrans.position += new Vector3(directionVector.x, 0f, 0f);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "floor")
        {
            jumping = false;
            canJump = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            enemies.Add(col.gameObject);
        }
    }
}
