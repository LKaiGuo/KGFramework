using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ce : MonoBehaviour {
public Material curMaterial;

[Range(-1,2)]
public float ww;
	// Use this for initialization
	void Start () {
		curMaterial=GetComponent<Image>().material;
	}
	
	// Update is called once per frame
	void Update () {
		curMaterial.SetFloat("_CenterY",ww);
	}
}
