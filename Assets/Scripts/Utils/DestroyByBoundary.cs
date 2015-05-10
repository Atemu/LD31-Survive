using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    public float padding = 0.0f;

    private float xMax;
    private float xMin;

    void Awake()
    {
        float xDist = Camera.main.aspect * Camera.main.orthographicSize;
        xMax = Camera.main.transform.position.x + (xDist + padding);
        xMin = Camera.main.transform.position.x - (xDist + padding);
    }

	void Start()
    {

    }

    void Update()
    {
        if (transform.position.x < xMin || transform.position.x > xMax)
        {
            Destroy(gameObject);
        }
    }

}
