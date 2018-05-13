using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

    public GameObject enemy, player;
    public float delayTime, appearHeight;
    private float time;

    // Use this for initialization
    void Start () {
        this.time = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        this.time += Time.deltaTime;
        if (this.time >= this.delayTime)
        {
            this.time -= this.delayTime;
            Vector3 rndPos = new Vector3(Random.Range(-50f, 50f), this.appearHeight, Random.Range(-50f, 50f));
            rndPos += this.player.transform.position;
            GameObject newEnemy = Instantiate(this.enemy, rndPos, this.transform.rotation);
            newEnemy.transform.parent = GameObject.Find("Enemies").transform;
            newEnemy.transform.Rotate(newEnemy.transform.up.normalized, Random.Range(0f, 360f));
        }
    }
}
