using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject leftStar, rightStar;
    private float jumpCoolTime, leftXscale, rightXscale;
    private Animator animator;

	// Use this for initialization
	void Start () {
        this.jumpCoolTime = 0f;
        this.animator = this.gameObject.GetComponent<Animator>();
        this.leftXscale = this.transform.localScale.x * -1f;
        this.rightXscale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        this.jumpCoolTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.jumpCoolTime <= 0f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 10, ForceMode2D.Impulse);
            this.jumpCoolTime = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += (3 * -Time.deltaTime * this.gameObject.transform.right);
            this.gameObject.transform.localScale = new Vector3(this.leftXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            this.animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += (3 * Time.deltaTime * this.gameObject.transform.right);
            this.gameObject.transform.localScale = new Vector3(this.rightXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            this.animator.SetBool("isWalking", true);
        }
        else
        {
            this.animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float xScale = this.transform.localScale.x;
            if(xScale >= 0) Instantiate(this.rightStar, this.transform.position + Vector3.up.normalized * 0.5f, this.transform.rotation);
            else Instantiate(this.leftStar, this.transform.position + Vector3.up.normalized * 0.5f, this.transform.rotation);
        }

    }
}
