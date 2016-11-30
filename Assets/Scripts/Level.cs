using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private int count;
	private GameObject[] getCount;
	private bool readyToSpawn = false;

	public Transform map;
	public Transform congaLine;
	public Transform spawnPrefab; 
	public Transform effectPrefab;
	public int maxEnemies = 12;
	public int distanceFromPlayer = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating("TimedSpawn", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	Vector3 GetLocationInMap () {
		Tiled2Unity.TiledMap mapScript = map.gameObject.GetComponent<Tiled2Unity.TiledMap>();
		float mapHeight = mapScript.TileHeight;
		float mapWidth = mapScript.TileWidth;

		// Get position in the map, approx,
		float randomX = (Random.Range(map.position.x + 1, map.position.x + mapWidth - 1));
		float randomY = (Random.Range(map.position.y - 1, map.position.y - mapHeight + 1));
		return new Vector3 (randomX, randomY, 0);
	}

	void TimedSpawn() {
		getCount = GameObject.FindGameObjectsWithTag ("Enemy");
		if (getCount.Length < maxEnemies) {
			Spawn ();
		}
	}

	void Spawn () {
		Vector3 spawnLocation = GetLocationInMap ();
		while (isCloseToPlayer(spawnLocation)) {
			spawnLocation = GetLocationInMap ();
		}

		Debug.Log ("Spawned at: " + spawnLocation.x + ',' + spawnLocation.y);
		Instantiate (effectPrefab, spawnLocation, Quaternion.identity);
		Instantiate (spawnPrefab, spawnLocation, Quaternion.identity);
	}

	bool isCloseToPlayer(Vector3 v) {
		foreach(Transform t in congaLine.GetComponent<SnakeMovement> ().bodyParts) {
			if (Vector3.Distance (v, t.position) < distanceFromPlayer) {
				return true;
			}
		}
		return false;
	}
}
