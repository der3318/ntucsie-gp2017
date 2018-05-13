using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(this.name.StartsWith("LeftStar")) this.gameObject.transform.position += (-5 * Time.deltaTime * this.gameObject.transform.right);
        else this.gameObject.transform.position += (5 * Time.deltaTime * this.gameObject.transform.right);
        float currentX = this.gameObject.transform.position.x;
        if (currentX < -10 || currentX > 10) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
