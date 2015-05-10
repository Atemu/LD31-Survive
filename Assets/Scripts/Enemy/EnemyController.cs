using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 2.0f;

    private float direction = 1.0f;
    private bool facingRight = true;

    public bool FacingRight
    {
        get
        {
            return facingRight;
        }
        set
        {
            facingRight = value;
        }
    }


	// Use this for initialization
	void Start () {
        if (!facingRight)
        {
            direction *= -1.0f;
            Flip();
        }
	}

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(direction, 0.0f);
        movement = movement.normalized * enemySpeed * Time.deltaTime;
        rigidbody2D.MovePosition(rigidbody2D.position + movement);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1.0f;
        transform.localScale = scale;
    }
}
