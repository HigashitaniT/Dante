using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour {
    List<SkinnedMeshRenderer> smr = new List<SkinnedMeshRenderer>();
    [SerializeField]
    Transform bookPar;
    [SerializeField, Range(0,100)]
    int blendValue;
	// Use this for initialization
	void Start () {
		foreach(Transform t in bookPar)
        {
            smr.Add(t.GetComponent<SkinnedMeshRenderer>());
          //  Debug.Log(t.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if((int)smr[0].GetBlendShapeWeight(0) != blendValue)
        {
            SetBlendValue(blendValue);
        }
	}

    public void SetBlendValue(int value)
    {
        foreach(SkinnedMeshRenderer s in smr)
        {
            s.SetBlendShapeWeight(0, value);
        }
    }
    public void OnValidate()
    {
        foreach (Transform t in bookPar)
        {
            smr.Add(t.GetComponent<SkinnedMeshRenderer>());
        }
        SetBlendValue(blendValue);
    }
}
