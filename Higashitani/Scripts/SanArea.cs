using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanArea : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Enemy") return;
		PlayerController.Instance.IsInSanArea = true;
        if (!other.GetComponent<Enemy>().IsFarst)
        {
            other.GetComponent<Enemy>().IsFarst = true;
            transform.parent.GetComponent<PlayerController>().StateAnimation(PlayerController.PlayerState.FastContact);
        }
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.tag != "Enemy") return;
		PlayerController.Instance.IsInSanArea = false;
	}
}
