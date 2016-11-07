using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
	public int tileX;
	public int tileY;
	public TileMap map;
	public List<Node> currentPath = null;

	int moveSpeed = 2;


	void Update() {
		if (currentPath !=null) {

			int currNode = 0;

			while ( currNode < currentPath.Count-1) {
				Vector3 start = map.TileCoordToWorldCoord( currentPath[currNode].x, currentPath[currNode].y) + new Vector3(0,0,-1f);
				Vector3 end = map.TileCoordToWorldCoord( currentPath[currNode + 1].x, currentPath[currNode + 1].y) + new Vector3(0,0,-1f);
				Debug.DrawLine(start, end, Color.red);
				currNode++;
			}
		}
	}
	public void MoveNextTile() {

		int remainingMovement = moveSpeed;

		while (remainingMovement > 0) {
			if (currentPath == null) return;
			//Removes nodes and moves on to the next
			remainingMovement -= (int) map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y);

			//Now grab the new first node and move us at the location
			tileX = currentPath[1].x;
			tileY =	currentPath[1].y;
			transform.position = map.TileCoordToWorldCoord( currentPath[1].x, currentPath[1].y);

			currentPath.RemoveAt(0);

			if(currentPath.Count == 1) {
				currentPath = null;
			}
		}
	}

}
