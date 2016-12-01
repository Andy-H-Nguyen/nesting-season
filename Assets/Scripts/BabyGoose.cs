using UnityEngine;
using System.Collections;

public class BabyGoose : MonoBehaviour {

	public Transform explosionPrefab;

	Vector3 _followOffset;

	void Start()
	{
	}

	void LateUpdate () 
	{
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0);
	}

	void OnCollisionEnter2D(Collision2D coll)  {
		// Do a gameover
		gameObject.GetComponent<AudioSource>().Play();
		gameObject.GetComponentInParent<SnakeMovement> ().bodyParts.Remove (gameObject.transform);
		Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
