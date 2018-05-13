using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float durationTime;
    private float time;

    // Use this for initialization
    void Start () {
        this.time = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        this.time += Time.deltaTime;
        if (this.time >= this.durationTime) Destroy(this.gameObject);
    }
}
