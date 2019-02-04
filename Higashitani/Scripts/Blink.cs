using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink {
    public static IEnumerator PlayBlink(int count, GameObject g)
    {
        for(int i = 0; i < count; i++)
        {
            foreach(Transform t in g.transform)
            {
                if(t.name != "SanArea"){
                    t.gameObject.SetActive(i % 2 == 0);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        foreach (Transform t in g.transform)
        {
            t.gameObject.SetActive(true);
        }
    }
}
