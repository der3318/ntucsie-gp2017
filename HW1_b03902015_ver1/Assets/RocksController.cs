using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksController : MonoBehaviour {

    public GameObject rock;
    public float delayTime, appearHeight;
    private float time;

	// Use this for initialization
	void Start () {
        this.time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        this.time += Time.deltaTime;
        if (this.time >= this.delayTime) {
            this.time -= this.delayTime;
            Vector3 rndPos = new Vector3(Random.Range(-4f, 4f), this.appearHeight, Random.Range(-4f, 4f));
            GameObject newRock = Instantiate(this.rock, rndPos, Random.rotation);
            newRock.transform.parent = GameObject.Find("Rocks").transform;
        }
	}

}
