using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeeingArea : MonoBehaviour {

    Enemy enemy;

    private void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    //視界範囲以内に入った処理
    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            enemy.Attack();
        }
    }

    //視界外に出た処理
    void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "Player")
        {
            //enemy.e.stay = false;
        }
    }
}
