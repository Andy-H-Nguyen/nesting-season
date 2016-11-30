using UnityEngine;
using System.Collections;

public class GenericAnimationHandler : MonoBehaviour {
	Animator anims;
	// Use this for initialization
	void Start () {
		anims = gameObject.GetComponent<Animator>();

	}

	Vector3 prevLoc = Vector3.zero;

	// Update is called once per frame
	void Update () {
		Vector3 curVel = (transform.position - prevLoc) / Time.deltaTime;
		if(curVel.y > 0)
		{
			if (Mathf.Abs (curVel.x) > Mathf.Abs (curVel.y)) {
				if (curVel.x > 0) {
					anims.Play ("WalkRight");
				} else {
					anims.Play ("WalkLeft");
				}
			} else {
				anims.Play ("WalkUp");
			}
		} else {
			if (Mathf.Abs (curVel.x) > Mathf.Abs (curVel.y)) {
				if (curVel.x > 0) {
					anims.Play ("WalkRight");
				} else {
					anims.Play ("WalkLeft");
				}
			} else {
				anims.Play ("WalkDown");
			}
		}
		prevLoc = transform.position;
	}
}
