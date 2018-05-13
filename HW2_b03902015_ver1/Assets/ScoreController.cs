using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text scoreText;
    private int score;

	// Use this for initialization
	void Start () {
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.text = "Score\n\n" + this.score;
	}

    public void AddScore()
    {
        this.score += 1;
    }
}
