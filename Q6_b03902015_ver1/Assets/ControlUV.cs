using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUV : MonoBehaviour {

    Material m_Material;
    float time, dir;

	// Use this for initialization
	void Start () {
        m_Material = this.GetComponent<SpriteRenderer>().material;
        time = 0f;
        dir = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 1f) {
            dir *= -1;
            time = 0f;
        }
        float uv_x = m_Material.GetVector("_Offset").x;
        float uv_y = m_Material.GetVector("_Offset").y;
        uv_x += Time.deltaTime * dir;
        uv_y += Time.deltaTime * dir;
        m_Material.SetVector("_Offset", new Vector4(uv_x, uv_y, 0.0f, 0.0f));
    }
}
