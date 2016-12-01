using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {
	private int count;
	private GameObject[] getCount;

	public Transform map;
	public Transform mapCollision;
	public Transform congaLine;
//	public Transform spawnPrefab; 
	public List<Transform> spawnPrefabs = new List<Transform>();
	public Transform effectPrefab;
	public int maxEnemies = 18;
	public int distanceFromPlayer = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating("TimedSpawn", 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	Vector3 GetLocationInMap () {
		Tiled2Unity.TiledMap mapScript = map.gameObject.GetComponent<Tiled2Unity.TiledMap>();
		float mapHeight = mapScript.TileHeight;
		float mapWidth = mapScript.TileWidth;

		// Get position in the map, approx,
		float randomX = (Random.Range(map.position.x + 2, map.position.x + mapWidth - 2));
		float randomY = (Random.Range(map.position.y - 2, map.position.y - mapHeight + 2));
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
		PolygonCollider2D mapCollider = mapCollision.GetComponent<PolygonCollider2D> ();

		while (isCloseToPlayer(spawnLocation)) {
			float distanceFromCollider = Vector3.Distance (spawnLocation, mapCollider.bounds.ClosestPoint(spawnLocation));

			if (mapCollider.bounds.Contains (spawnLocation) || distanceFromCollider < 3f) {
				return;
			}
			spawnLocation = GetLocationInMap ();
		}

		Random r = new Random();
		int index = Random.Range(0,spawnPrefabs.Count);

		Instantiate (effectPrefab, spawnLocation, Quaternion.identity);
		Instantiate (spawnPrefabs[index], spawnLocation, Quaternion.identity);
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
