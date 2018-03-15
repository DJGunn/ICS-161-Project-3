using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scale = .015f * (20f + Mathf.Cos(Time.time * (132f / 60) * Mathf.PI * 2));
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
