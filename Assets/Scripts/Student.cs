using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public Transform explosionPrefab;

	void OnCollisionEnter2D(Collision2D coll) {
		Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
