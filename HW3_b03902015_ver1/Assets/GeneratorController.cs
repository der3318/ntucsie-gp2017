using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    public GameObject stair;
    private float time, totalTime;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game").GetComponent<GameController>().isActive == false)
        {
            time = 0f;
            return;
        }
        time += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (time > 1f + totalTime / 60f)
        {
            time -= (1f + totalTime / 60f);
            Vector3 pos = new Vector3(Random.Range(-10f, 0f), -9f, 0f);
            GameObject obj = Instantiate(stair, pos, this.transform.rotation);
            GameObject.Find("Game").SendMessage("AddScore");
        }
    }

    public void Init()
    {
        time = 0f;
        totalTime = 0f;
        GameObject obj = Instantiate(stair, new Vector3(0, -9f, 0f), this.transform.rotation);
     }

}
