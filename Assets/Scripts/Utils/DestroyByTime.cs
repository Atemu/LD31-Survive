using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float timeToLive = 5.0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, timeToLive);
	}
}
