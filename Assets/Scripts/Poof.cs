using UnityEngine;
using System.Collections;

public class Poof : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Delete"))
			Destroy (gameObject);
	}
}
