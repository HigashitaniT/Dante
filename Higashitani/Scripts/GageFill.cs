using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageFill : MonoBehaviour {
    [SerializeField]
    RectTransform rt;
    [SerializeField, Range(0, 1)]
    float fillValue = 0;
    float fillMin = 645f;
    [SerializeField]
    Image image;

    public float FillValue
    {
        set { fillValue = value; }
        get { return fillValue; }
    }

	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 0~1でfill
    /// </summary>
    /// <param name="val"></param>
    public void Fill(float val)
    {
        fillValue = val;
        rt.offsetMax = new Vector2(Mathf.Lerp(0, -fillMin, Mathf.Abs(val-1)), 0);
        FillColor(val);
    }

    public void OnValidate()
    {
        Fill(fillValue);
    }

    public void FillColor(float val) {
        Color c = image.color;
        if (val < 0.5f)
        {
            c.g = Mathf.Lerp(0, 1, val*2);
        }
        else
        {
            c.r = Mathf.Lerp(1, 0, val*2-1);
        }
        image.color = c;
    }

}
