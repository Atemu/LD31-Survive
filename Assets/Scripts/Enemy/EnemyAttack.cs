using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private GameManager gameManager;

    void Awake()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameObject != null)
        {
            gameManager = gameObject.GetComponent<GameManager>();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
    }
}
