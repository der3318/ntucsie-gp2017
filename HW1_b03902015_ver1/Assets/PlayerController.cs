using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed, rotateRatio, jumpDuration, restDelayTime;
    public Text playerTextIcon;
    private GameObject chanObject;
    private Animator chanAnimator;
    private GameObject[] cameras;
    private float curJumpDuration, curRestTime;
    
	// Use this for initialization
	void Start () {
        this.chanObject = this.transform.FindChild("unitychan").gameObject;
        this.chanAnimator = this.transform.FindChild("unitychan").gameObject.GetComponent<Animator>();
        this.cameras = new GameObject[2];
        this.cameras[0] = this.transform.FindChild("MainCamera1").gameObject;
        this.cameras[1] = this.transform.FindChild("MainCamera2").gameObject;
        this.cameras[0].SetActive(true);
        this.cameras[1].SetActive(false);
        this.curJumpDuration = 0f;
        this.curRestTime = this.restDelayTime;
    }
	
	// Update is called once per frame
	void Update () {
        // select camera
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (this.cameras[0].activeInHierarchy) {
                this.cameras[0].SetActive(false);
                this.cameras[1].SetActive(true);
            }
            else {
                this.cameras[0].SetActive(true);
                this.cameras[1].SetActive(false);
            }
        }
        // reset animation
        this.chanAnimator.SetFloat("Speed", 0f);
        // rotate
        float mouseX = Input.GetAxis("Mouse X");
        this.gameObject.transform.Rotate(this.gameObject.transform.up.normalized, mouseX * this.rotateRatio);
        this.chanObject.transform.Rotate(this.gameObject.transform.up.normalized, -mouseX * this.rotateRatio);
        // reset jump
        if (this.chanAnimator.GetBool("Jump")) this.curJumpDuration += Time.deltaTime;
        if (this.curJumpDuration >= this.jumpDuration) {
            this.chanAnimator.SetBool("Jump", false);
            this.curJumpDuration = 0f;
        }
        // reset rest
        this.chanAnimator.SetBool("Rest", false);
        this.curRestTime += Time.deltaTime;
        if (this.curRestTime >= this.restDelayTime) {
            this.chanAnimator.SetBool("Rest", true);
            this.curRestTime = 0f;
        }
        // disable movement if end game
        if (GameObject.Find("Game").GetComponent<GameController>().isEnding) return;
        // move and rotate chan girl
        float deltaRotation = 90;
        if (Input.GetKey(KeyCode.W)) {
            this.gameObject.transform.position += (this.gameObject.transform.forward.normalized * this.moveSpeed * Time.deltaTime);
            this.chanAnimator.SetFloat("Speed", 1f);
            this.chanObject.transform.rotation = this.gameObject.transform.rotation;
            deltaRotation = 45f;
        }
        if (Input.GetKey(KeyCode.S)) {
            this.gameObject.transform.position -= (this.gameObject.transform.forward.normalized * this.moveSpeed * Time.deltaTime);
            this.chanAnimator.SetFloat("Speed", -1f);
            this.chanObject.transform.rotation = this.gameObject.transform.rotation;
            deltaRotation = 135f;
        }
        if (Input.GetKey(KeyCode.D)) {
            this.gameObject.transform.position += (this.gameObject.transform.right.normalized * this.moveSpeed * Time.deltaTime);
            this.chanAnimator.SetFloat("Speed", 1f);
            this.chanObject.transform.rotation = this.gameObject.transform.rotation;
            this.chanObject.transform.Rotate(this.gameObject.transform.up.normalized, deltaRotation);
        }
        if (Input.GetKey(KeyCode.A)) {
            this.gameObject.transform.position -= (this.gameObject.transform.right.normalized * this.moveSpeed * Time.deltaTime);
            this.chanAnimator.SetFloat("Speed", 1f);
            this.chanObject.transform.rotation = this.gameObject.transform.rotation;
            this.chanObject.transform.Rotate(this.gameObject.transform.up.normalized, -deltaRotation);
        }
        this.playerTextIcon.rectTransform.offsetMin = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z);
    }
    
}
