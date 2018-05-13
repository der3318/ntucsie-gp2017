using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed, rotateSpeed, bulletReloadTime;
    private float time;
    private int numBullets;
    private Animator animator;
    public GameObject bullet;

    // Use this for initialization
    void Start () {
        this.time = 0f;
        this.numBullets = 5;
        this.animator = this.transform.FindChild("war_transport_drk_green").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // rotate animation
        this.animator.SetBool("right", false);
        this.animator.SetBool("left", false);
        if (Input.GetKey(KeyCode.RightArrow))
            this.animator.SetBool("right", true);
        if (Input.GetKey(KeyCode.LeftArrow))
            this.animator.SetBool("left", true);
        // move
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (this.animator.GetBool("right"))
                this.gameObject.transform.Rotate(this.gameObject.transform.up.normalized, this.rotateSpeed * Time.deltaTime);
            if (this.animator.GetBool("left"))
                this.gameObject.transform.Rotate(this.gameObject.transform.up.normalized, -this.rotateSpeed * Time.deltaTime);
            this.gameObject.transform.position += (this.gameObject.transform.forward.normalized * this.moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (this.animator.GetBool("right"))
                this.gameObject.transform.Rotate(this.gameObject.transform.up.normalized, -this.rotateSpeed * Time.deltaTime);
            if (this.animator.GetBool("left"))
                this.gameObject.transform.Rotate(this.gameObject.transform.up.normalized, this.rotateSpeed * Time.deltaTime);
            this.gameObject.transform.position -= (this.gameObject.transform.forward.normalized * this.moveSpeed * Time.deltaTime);
        }
        // fire
        if (Input.GetKeyDown(KeyCode.Space) && this.numBullets > 0){
            this.numBullets -= 1;
            Instantiate(this.bullet, this.transform.position + 4 * this.transform.forward.normalized + this.transform.up.normalized, this.transform.rotation);
        }
        // reload bullet
        if (this.numBullets < 5) this.time += Time.deltaTime;
        if (this.time >= this.bulletReloadTime)
        {
            this.time = 0;
            this.numBullets += 1;
        }
        // update canvas
        GameObject.Find("BulletImgs").SendMessage("UpdateCanvas", this.numBullets);
    }
}
