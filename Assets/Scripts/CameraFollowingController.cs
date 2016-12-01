using UnityEngine;
using System.Collections;

public class CameraFollowingController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	public Transform congaLine;
	public int baseFov = 60;
	public int maxFov = 100;
	public int fovIncreaseModifier = 5;
	public int fovIncreaseRatio = 1;


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private int cameraZoom = 5;
	private Vector3 zoomVector;
	// Use this for initialization
	void Start () 
	{
		zoomVector = new Vector3 (0, 0, cameraZoom);
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	void Update () 
	{
		int lineSize = congaLine.GetComponent<SnakeMovement> ().GetLength();

		int newFov = baseFov + fovIncreaseModifier * (lineSize / fovIncreaseRatio);  
		if (newFov < maxFov) {
			newFov = baseFov + fovIncreaseModifier * (lineSize / fovIncreaseRatio); 
		}
		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, newFov, Time.deltaTime);
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{

		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
	}
}
