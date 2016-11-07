﻿using UnityEngine;
using System.Collections.Generic;

public class Node {
	public List<Node> neighbours;
	public int x;
	public int y;
	
	public Node() {
		neighbours = new List<Node>();
	}

    public object Sort { get; internal set; }

    public float DistanceTo(Node n) {
		if(n == null) {
			Debug.LogError("WTF?");
		}
		
		return Vector2.Distance(
			new Vector2(x, y),
			new Vector2(n.x, n.y)
			);
	}
}
