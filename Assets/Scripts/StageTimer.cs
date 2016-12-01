using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageTimer : MonoBehaviour {
	public float timeLeft = 120;

	public GameObject levelManager;
	public GameObject UIBlock;
	// Use this for initialization
	void Start () {
		UIBlock.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Time.timeScale = 0;

			UIBlock.SetActive (true);
		}

		Text txt = gameObject.GetComponent<Text> ();
		txt.text = "Time: " + (int) timeLeft;
	}

	void EndGame () {
		levelManager.GetComponent<LevelManager> ().LoadLevel ("Start Menu");
	}
}
