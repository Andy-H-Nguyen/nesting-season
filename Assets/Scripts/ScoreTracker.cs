using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public Transform congaLine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text txt = gameObject.GetComponent<Text> ();
		txt.text = "Score: " + (congaLine.GetComponent<SnakeMovement>().GetLength() - 1);
	}
}
