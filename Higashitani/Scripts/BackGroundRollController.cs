using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRollController : MonoBehaviour {
    OffsetScroller[] os = new OffsetScroller[3];
	
    // Use this for initialization
	void Start () {
        for(int i = 0; i < os.Length; i++)
        {
            os[i] = transform.Find("BackGround_" + (i+1).ToString()).GetComponent<OffsetScroller>();

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScrollHorizontal(float speed)
    {
        for(int i = 0; i < os.Length; i++)
        {
            os[i].OffsetScrollHorizontal(speed);
        }
    }

    public void ScrollVertex(float speed)
    {
        for (int i = 0; i < os.Length; i++)
        {
            os[i].OffsetScrollVertex(speed);
        }
    }
}
