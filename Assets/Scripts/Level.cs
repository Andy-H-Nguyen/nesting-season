using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private int count;
	private GameObject[] getCount;

	public Transform spawnPrefab; 
	public int maxEnemies = 10;

	// Use this for initialization
	void Start () {
		getCount = GameObject.FindGameObjectsWithTag ("Respawn");
		count = getCount.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GetFreeLocation () {

	}
}
