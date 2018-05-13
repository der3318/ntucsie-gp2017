using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up.normalized * this.moveSpeed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward.normalized * this.moveSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider _col)
    {
        Destroy(this.gameObject);
    }
}
