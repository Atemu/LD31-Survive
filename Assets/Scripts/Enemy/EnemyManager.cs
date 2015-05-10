using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public Transform spawnLeft;
    public Transform spawnRight;
    public int hazardCount = 2;
    public int maxHazardCount = 20;
    public float spawnWait = 1.0f;
    public float startWait = 1.0f;
    public float waveWait = 3.0f;
    public int addingEnemies = 2;
    public float speedUp = 0.2f;
    public Text nextWaveText;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnAmmoBoxWaves());
	}

    void FixedUpdate()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.isGameOver)
        {
            nextWaveText.gameObject.SetActive(false);
        }
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

            nextWaveText.gameObject.SetActive(false);
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject enemySpawned = Instantiate(enemy, spawnLeft.position, spawnLeft.rotation) as GameObject;
                enemySpawned.transform.parent = spawnLeft;

                enemySpawned = Instantiate(enemy, spawnRight.position, spawnRight.rotation) as GameObject;
                enemySpawned.transform.parent = spawnRight;
                enemySpawned.GetComponent<EnemyController>().FacingRight = false;

                yield return new WaitForSeconds(spawnWait);
            }

            if (hazardCount < maxHazardCount)
            {
                hazardCount += addingEnemies;
            }

            float spawnValue = spawnWait - speedUp;

            if (spawnValue > 0.8f)
            {
                spawnWait = spawnValue;
            }

            nextWaveText.gameObject.SetActive(true);
            yield return new WaitForSeconds(waveWait);
        }
    }

}
