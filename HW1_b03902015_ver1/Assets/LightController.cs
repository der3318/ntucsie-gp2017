using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public float descendSpeed;

    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Light>().intensity = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Game").GetComponent<GameController>().isEnding)
            this.gameObject.GetComponent<Light>().intensity -= (this.descendSpeed * Time.deltaTime);
        else if (this.gameObject.GetComponent<Light>().intensity < 1f) {
            this.gameObject.GetComponent<Light>().intensity += (this.descendSpeed * Time.deltaTime);
            if (this.gameObject.GetComponent<Light>().intensity > 1f) this.gameObject.GetComponent<Light>().intensity = 1f;
        }
    }

}
