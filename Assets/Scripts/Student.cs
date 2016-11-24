using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

	public Transform explosionPrefab;

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate(explosionPrefab, pos, rot);
		Destroy(gameObject);
	}
}
