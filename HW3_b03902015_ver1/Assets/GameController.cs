using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int curScore, highScore;
    public bool isActive;
    public Text current, high, hint;
    public Image heart;

	// Use this for initialization
	void Start () {
        this.SendMessage("GameOver");
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            hint.gameObject.SetActive(false);
            heart.gameObject.SetActive(true);
        }
        else
        {
            hint.gameObject.SetActive(true);
            heart.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space) && isActive == false) this.SendMessage("GameStart");
        current.text = "Current Score\n" + curScore;
        high.text = "High Score\n" + highScore;
    }

    public void GameStart()
    {
        curScore = 0;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Stair");
        for (int i = 0; i < gameObjects.Length; i++) Destroy(gameObjects[i]);
        GameObject.Find("StairGenerator").SendMessage("Init");
        GameObject.Find("Angie").SendMessage("Init");
        isActive = true;
    }

    public void GameOver()
    {
        isActive = false;
        if (curScore > highScore) highScore = curScore;
    }

    public void AddScore()
    {
        curScore++;
    }

}
