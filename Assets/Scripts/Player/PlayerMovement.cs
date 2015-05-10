using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3.0f;

    private Vector3 movement;
    private Rigidbody2D playerRigidbidy;
    private bool facingRight = true;

    public bool FacingRight
    {
        get
        {
            return facingRight;
        }
    }

    void Awake()
    {
        playerRigidbidy = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Move(h);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }

	// Update is called once per frame
	void Update () {

	}

    private void Move(float h)
    {
        movement.Set(h, 0.0f, 0.0f);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbidy.MovePosition(transform.position + movement);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        transform.localScale = scale;
    }
}
