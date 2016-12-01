using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageTimer : MonoBehaviour {
	float timeLeft = 120;

	public GameObject levelManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			levelManager.GetComponent<LevelManager> ().LoadLevel ("Start Menu");
		}
			
		Text txt = gameObject.GetComponent<Text> ();
		txt.text = "Time: " + (int) timeLeft;
	}
}
