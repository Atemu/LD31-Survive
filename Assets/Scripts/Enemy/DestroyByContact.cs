using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public AudioClip destroySound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            ScoreManager.score++;
            audio.PlayOneShot(destroySound);
            Destroy(other.gameObject);
            gameObject.renderer.enabled = false;
            Destroy(gameObject, destroySound.length);
        }
    }

}
