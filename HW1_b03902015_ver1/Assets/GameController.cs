using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject congratulationImg;
    public bool isEnding;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        this.congratulationImg.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (this.isEnding) this.congratulationImg.SetActive(true);
	}
}
