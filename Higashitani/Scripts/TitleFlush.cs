using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFlush : MonoBehaviour {
    [SerializeField]
    float val;
    Material mt;
	// Use this for initialization
	void Start () {
        mt = GetComponent<Image>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if (val >= 3.14f) return;
        mt.SetFloat("_SinVal", val);
	}
}
