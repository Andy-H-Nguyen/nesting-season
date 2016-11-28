using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private int count;
	private GameObject[] getCount;

	// Use this for initialization
	void Start () {
		getCount = GameObject.FindGameObjectsWithTag ("Respawn");
		count = getCount.Length;
		Debug.Log (count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
