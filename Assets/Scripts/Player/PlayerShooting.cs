using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public Transform shotSpawn;
    public GameObject projectile;
    public float fireRate = 0.3f;
    public int initAmmo = 10;
    public Text ammoUI;
    public float projectileVelocity = 500.0f;
    public AudioClip fireSound;
    public AudioClip pickupSound;

    private PlayerMovement playerMovement;
    private float nextFire = 0.0f;
    private float ammo;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ammo = initAmmo;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!PickUp())
            {
                Shoot();
            }
        }
        ammoUI.text = "Ammo: " + ammo;
	}

    private void Shoot()
    {
        if (Time.time > nextFire && ammo > 0)
        {
            nextFire = Time.time + fireRate;
            GameObject projectileFired = Instantiate(projectile, shotSpawn.position, shotSpawn.rotation) as GameObject;
            audio.PlayOneShot(fireSound);

            Vector3 projectileDirection = Vector3.zero;
            if (playerMovement.FacingRight == true)
            {
                projectileDirection = Vector2.right;
            }
            else
            {
                projectileDirection = -Vector2.right;
            }

            projectileFired.rigidbody2D.AddForce(projectileDirection * projectileVelocity);
            --ammo;
        }
    }

    private bool PickUp()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D ammoHit = Physics2D.Raycast(cameraRay.origin, cameraRay.direction);
        if (ammoHit.collider != null && ammoHit.transform.gameObject.tag == "Ammo")
        {
            ammo += initAmmo;
            audio.PlayOneShot(pickupSound);
            ammoHit.transform.gameObject.renderer.enabled = false;
            Destroy(ammoHit.transform.gameObject, pickupSound.length);
            return true;
        }

        if (ammoHit.collider != null)
            Debug.Log(ammoHit.transform.gameObject.tag);

        return false;
    }

}
