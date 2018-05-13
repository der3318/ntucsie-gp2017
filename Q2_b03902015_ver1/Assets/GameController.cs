using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject cube, bullectObject;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(60, 5, 100, 20), "forward"))
            this.cube.GetComponent<Rigidbody>().AddForce(this.cube.transform.forward.normalized * this.moveSpeed, ForceMode.Impulse);
        if (GUI.Button(new Rect(60, 55, 100, 20), "backward"))
            this.cube.GetComponent<Rigidbody>().AddForce(-this.cube.transform.forward.normalized * this.moveSpeed, ForceMode.Impulse);
        if (GUI.Button(new Rect(5, 30, 100, 20), "left"))
            this.cube.GetComponent<Rigidbody>().AddForce(-this.cube.transform.right.normalized * this.moveSpeed, ForceMode.Impulse);
        if (GUI.Button(new Rect(115, 30, 100, 20), "right"))
            this.cube.GetComponent<Rigidbody>().AddForce(this.cube.transform.right.normalized * this.moveSpeed, ForceMode.Impulse);
        if (GUI.Button(new Rect(60, 105, 100, 20), "fire"))
            Instantiate(this.bullectObject, this.cube.transform.position + this.cube.transform.forward.normalized, this.cube.transform.rotation);
    }
}
