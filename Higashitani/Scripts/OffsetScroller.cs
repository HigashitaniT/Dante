using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour {
	Material mt;
	[SerializeField]
	float scrollSpeed;
	Vector2 mtOffset;
	// Use this for initialization
	void Start () {
		mt = GetComponent<MeshRenderer>().material;
	}
	void Update () {
		
	}

	/// <summary>
	/// 上下動
	/// </summary>
	/// <param name="speed"></param>
	public void OffsetScrollVertex(float speed){
		mtOffset = mt.GetTextureOffset("_MainTex");
		mtOffset.y += speed * scrollSpeed;
		mt.SetTextureOffset("_MainTex", mtOffset);
	}

	/// <summary>
	/// 左右動
	/// </summary>
	/// <param name="speed"></param>
	public void OffsetScrollHorizontal(float speed){
		mtOffset = mt.GetTextureOffset("_MainTex");
		mtOffset.x += speed * scrollSpeed;
		mt.SetTextureOffset("_MainTex", mtOffset);
	}
}
