using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private int count;
	private GameObject[] getCount;

	public Transform map;
	public Transform spawnPrefab; 
	public Transform effectPrefab;
	public int maxEnemies = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		getCount = GameObject.FindGameObjectsWithTag ("Enemy");
		if (getCount.Length < maxEnemies) {
			Spawn ();
		}
		// Debug.Log (getCount.Length);
	}

	Vector3 GetLocationInMap () {
		Tiled2Unity.TiledMap mapScript = map.gameObject.GetComponent<Tiled2Unity.TiledMap>();
		float mapHeight = mapScript.GetMapHeightInPixelsScaled();
		float mapWidth = mapScript.GetMapWidthInPixelsScaled();
		float randomX = Mathf.Abs (Random.Range(-(mapWidth/2), (mapWidth/2)));
		float randomY = Mathf.Abs (Random.Range(-(mapHeight/2), (mapHeight/2)));
		return new Vector3 (randomX, randomY, 0);
	}

	void Spawn () {
		Vector3 spawnLocation = GetLocationInMap ();
		Debug.Log (spawnLocation.x + spawnLocation.y);
		Instantiate (effectPrefab, spawnLocation, Quaternion.identity);
		Instantiate (spawnPrefab, spawnLocation, Quaternion.identity);
	}
}
