using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float leftXscale, rightXscale;
    private Animator animator;

	// Use this for initialization
	void Start () {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.leftXscale = this.transform.localScale.x * -1f;
        this.rightXscale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Game").GetComponent<GameController>().isActive == false)
        {
            this.animator.SetBool("isWalking", false);
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += (5 * -Time.deltaTime * this.gameObject.transform.right);
            this.gameObject.transform.localScale = new Vector3(this.leftXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            this.animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += (5 * Time.deltaTime * this.gameObject.transform.right);
            this.gameObject.transform.localScale = new Vector3(this.rightXscale, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            this.animator.SetBool("isWalking", true);
        }
        else
        {
            this.animator.SetBool("isWalking", false);
        }
    }

    public void Init()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.transform.position = new Vector3(0, -8, 0);
    }
}
