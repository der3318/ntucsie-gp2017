using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //gameover
            GameObject.Find("Game").SendMessage("GameOver");
        }
        else if(other.tag == "Stair"){
            Destroy(other.gameObject, 1f);
        }
    }
}
