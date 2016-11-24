using UnityEngine;
using System.Collections;

public class MamaGoose : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (speed, 0);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			rb.velocity = new Vector2 (0, -speed);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-speed, 0);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			rb.velocity = new Vector2 (0, speed);
		}
	}
}
