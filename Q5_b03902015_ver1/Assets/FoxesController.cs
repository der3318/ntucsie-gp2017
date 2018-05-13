using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxesController : MonoBehaviour {

    public GameObject fox;
    private float delayTime, time;

	// Use this for initialization
	void Start () {
        this.delayTime = 5f;
        this.time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        this.time += Time.deltaTime;
        if (this.time >= this.delayTime)
        {
            this.time -= this.delayTime;
            Vector3 rndPos = new Vector3(Random.Range(-5f, 5f), 4, 0);
            GameObject newFox = Instantiate(this.fox, rndPos, this.transform.rotation);
            newFox.transform.parent = GameObject.Find("Foxes").transform;
        }

	}
}
