using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public Text volText;
    private float startTouchPosition, endTouchPosition;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began) startTouchPosition = touch.position.y;
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position.y;
                if (endTouchPosition > startTouchPosition) this.GetComponent<AudioSource>().volume += 0.1f;
                else if (endTouchPosition < startTouchPosition) this.GetComponent<AudioSource>().volume -= 0.1f;
            }

        }
        this.volText.text = "Vol " + (int)(this.GetComponent<AudioSource>().volume * 100f) + "%";
    }

}
