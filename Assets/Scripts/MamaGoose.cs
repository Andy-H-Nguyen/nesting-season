using UnityEngine;
using System.Collections;

public class MamaGoose : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		rb.velocity = new Vector2 (0, -speed);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (speed, 0);
			GetComponent<Animator>().Play ("MamaGooseWalkRight");
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			rb.velocity = new Vector2 (0, -speed);
			GetComponent<Animator>().Play ("MamaGooseWalkDown");
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-speed, 0);
			GetComponent<Animator>().Play ("MamaGooseWalkLeft");
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			rb.velocity = new Vector2 (0, speed);
			GetComponent<Animator>().Play ("MamaGooseWalkUp");
		}
	}
}
