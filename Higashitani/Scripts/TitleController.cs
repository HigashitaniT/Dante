using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
    [SerializeField]
    string selectSceneName;
    [SerializeField]
    List<Animator> openAnim = new List<Animator>();

    [SerializeField]
    Text tapText;

    Coroutine coroutine;

    bool isTouch = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TapScreen()
    {
        if (isTouch) { return; }
        isTouch = true;
        StartCoroutine(SendScene());
    }

    IEnumerator SendScene()
    {
        foreach (Animator a in openAnim)
        {
            a.SetTrigger("Open");
        }
        yield return StartCoroutine(BlineText(tapText));
        //SceneManager.LoadScene(selectSceneName);
        FadeManager.Instance.StartFade(true, "Select");
    }

    IEnumerator BlineText(Text text)
    {
        var defColor = text.material.color;
        foreach(Animator a in openAnim)
        {
            a.SetTrigger("Open");
        }
        for(int i = 0; i < 10; i++)
        {
            text.material.color = new Color(defColor.r, defColor.g, defColor.b, i % 2);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
