using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player") GameObject.Find("Game").GetComponent<GameController>().isEnding = true;
    }

}
