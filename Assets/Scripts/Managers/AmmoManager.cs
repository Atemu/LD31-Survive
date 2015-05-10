using UnityEngine;
using System.Collections;

public class AmmoManager : MonoBehaviour {

    public GameObject ammo;
    public Vector2 spawnValues;
    public int hazardCount = 2;
    public float spawnWait = 3.0f;
    public float startWait = 1.0f;
    public float waveWait = 4.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnAmmoBoxWaves());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator SpawnAmmoBoxWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (GameManager.isGameOver)
            {
                break;
            }

            for (int i = 0; i < hazardCount; i++)
            {
                if (GameManager.isGameOver)
                {
                    break;
                }

                Vector2 position = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                GameObject ammoSpawned = Instantiate(ammo, position, transform.rotation) as GameObject;
                ammoSpawned.transform.parent = gameObject.transform;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
