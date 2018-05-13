using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImgsControlelr : MonoBehaviour {

    public GameObject[] bulletImgs;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateCanvas(int _numBullets)
    {
        for(int i = 0; i < bulletImgs.Length; i++)
        {
            if (i < _numBullets) bulletImgs[i].SetActive(true);
            else bulletImgs[i].SetActive(false);
        }
    }

}
