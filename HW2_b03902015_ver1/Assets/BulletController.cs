using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float moveSpeed;
    public GameObject fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position += (this.gameObject.transform.forward.normalized * this.moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == "Target")
        {
            GameObject.Find("Score").SendMessage("AddScore");
            Destroy(_col.gameObject);
            Instantiate(this.fire, this.transform.position, this.transform.rotation);
        }
        Destroy(this.gameObject);
    }
}
