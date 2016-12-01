using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour {

	public AudioSource musicSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound() {
		musicSource.Play();
	}
}
