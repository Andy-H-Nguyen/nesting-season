using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SnakeMovement : MonoBehaviour {

	public List<Transform> bodyParts = new List<Transform>();

	public float speed = 1;
	public float rotationSpeed = 50;
	public float minDistance = 0.25f;

	public int beginSize = 1;

	public GameObject bodyPrefab;
	public GameObject spawnPrefab;

	private float dis;
	private Transform curBodyPart;
	private Transform prevBodyPart;

	// Use this for initialization
	void Start () {
		prevBodyPart = bodyParts [0];
		for (int i = 0; i < beginSize - 1; i++) {
			AddBodyPart ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

		if (Input.GetKey(KeyCode.Q))
			AddBodyPart ();
	}

	public void Move() {
		float curSpeed = speed;

		if (Input.GetKey (KeyCode.W))
			curSpeed *= 2;

		bodyParts [0].Translate (bodyParts [0].forward * curSpeed * Time.smoothDeltaTime, Space.World);

//		if (Input.GetAxis ("Horizontal") != 0)
//			bodyParts [0].Rotate (Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"));

		for(int i = 1; i < bodyParts.Count; i++) {
				curBodyPart = bodyParts[i];
				prevBodyPart = bodyParts[i-1];
				
				// Don't collide with previous segment
				Physics2D.IgnoreCollision(prevBodyPart.GetComponent<Collider2D>(), curBodyPart.GetComponent<Collider2D>());

				curBodyPart.position = new Vector3(curBodyPart.position.x, curBodyPart.position.y, 0);
				prevBodyPart.position = new Vector3(prevBodyPart.position.x, prevBodyPart.position.y, 0);
				
				dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

				Vector3 newPos = prevBodyPart.position;

				newPos.z = bodyParts[0].position.z;

				float T = Time.deltaTime * dis / minDistance * curSpeed;

				if(T > 0.5f) 
					T = 0.5f;

				curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
				 curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
		}
	}

	public void AddBodyPart() {
		Transform newPart = (Instantiate(
			bodyPrefab, 
			bodyParts[bodyParts.Count - 1].position, 
			bodyParts[bodyParts.Count - 1].rotation)
			as GameObject).transform;

		Transform spawnPoof = (Instantiate(
			spawnPrefab, 
			bodyParts[bodyParts.Count - 1].position, 
			bodyParts[bodyParts.Count - 1].rotation)
			as GameObject).transform; 

		newPart.SetParent (transform);
		bodyParts.Add (newPart);
	}
}
