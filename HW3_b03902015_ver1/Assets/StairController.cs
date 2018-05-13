using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour {

    private bool movable;
    private Vector3 moveDir;

	// Use this for initialization
	void Start () {
        movable = false;
        moveDir = new Vector3(3, 0, 0);
        float rnd = Random.Range(0f, 1f);
        if (rnd > 0.8f)
        {
            movable = true;
            if (this.gameObject.transform.position.x < -5f) moveDir = new Vector3(3, 0, 0);
            else moveDir = new Vector3(-3, 0, 0);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(movable == true && this.gameObject.transform.position.x < 2f && this.gameObject.transform.position.x > -12f)
        {
            this.gameObject.transform.position += moveDir * Time.deltaTime;
        }
        if (GameObject.Find("Game").GetComponent<GameController>().isActive) this.gameObject.transform.position += new Vector3(0, 3, 0) * Time.deltaTime;
	}

}
