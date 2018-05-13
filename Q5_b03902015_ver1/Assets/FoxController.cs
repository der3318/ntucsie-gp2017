using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour {

    private GameObject player;
    private float leftXscale, rightXscale;

    // Use this for initialization
    void Start () {
        this.player = GameObject.Find("Angie").gameObject;
        this.leftXscale = this.transform.localScale.x * -1f;
        this.rightXscale = this.transform.localScale.x;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 deltaPosition = (this.player.gameObject.transform.position - this.gameObject.transform.position).normalized;
        this.transform.position += (1 * Time.deltaTime * deltaPosition);
        if (deltaPosition.x >= 0)
            this.gameObject.transform.localScale = new Vector3(this.rightXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        else
            this.gameObject.transform.localScale = new Vector3(this.leftXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

    }
}
