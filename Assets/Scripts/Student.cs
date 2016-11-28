using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public Transform explosionPrefab;
	private Rigidbody2D rb;
	private bool walkForward; 
	private bool walkInX; // Walks in Y direction if false

	private float initialX;
	private float initialY;
	private float WalkRange = 2.0f; // Range of motion
	private float speed = 2.0f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;

		initialX = transform.position.x;
		initialY = transform.position.y;

		WalkRange = Random.Range (1f, 4f);
		speed = Random.Range (1f, 4f);

		if (Random.Range (0f, 1f) < 0.5f) {
			walkInX = false;
		} else {
			walkInX = true;
		}
	}

	void Update () {
		if (walkInX) {
			if (walkForward)
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.right * speed * Time.deltaTime);

			if (transform.position.x >= initialX + WalkRange) {
				walkForward = false;
			}

			if (transform.position.x <= initialX - WalkRange) {
				walkForward = true;
			}
		}

		if (!walkInX) {
			if (walkForward)
				transform.Translate (Vector2.up * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.up * speed * Time.deltaTime);

			if (transform.position.y >= initialX + WalkRange) {
				walkForward = false;
			}

			if (transform.position.y <= initialX - WalkRange) {
				walkForward = true;
			}
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.name == "MamaGoose") {
			Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		} else {
			// Hit with object, recalculate position
			walkForward = !walkForward;
			initialX = transform.position.x;
			initialY = transform.position.y;

		}
	}
}
