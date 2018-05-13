using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetController : MonoBehaviour {

    public float springForce;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Player") {
            _col.gameObject.GetComponent<Rigidbody>().AddForce(_col.gameObject.transform.up.normalized * springForce, ForceMode.Impulse);
            _col.gameObject.transform.FindChild("unitychan").gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }
    }

}
