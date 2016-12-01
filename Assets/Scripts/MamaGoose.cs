using UnityEngine;
using System.Collections;

public class MamaGoose : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform lastPiece;

	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		rb.velocity = new Vector2 (0, -speed);
		lastPiece = transform;
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

	public void PlayAttack() {
		gameObject.GetComponent<AudioSource> ().Play ();
		Animator anim = gameObject.GetComponent<Animator> ();
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("MamaGooseWalkRight")) {
			anim.Play ("MamaGooseAttackRight");
		} else if(anim.GetCurrentAnimatorStateInfo (0).IsName ("MamaGooseWalkDown")) {
			anim.Play ("MamaGooseAttackDown");
		} else if(anim.GetCurrentAnimatorStateInfo (0).IsName ("MamaGooseWalkLeft")) {
			anim.Play ("MamaGooseAttackLeft");
		} else if(anim.GetCurrentAnimatorStateInfo (0).IsName ("MamaGooseWalkUp")) {
			anim.Play ("MamaGooseAttackUp");
		}

	}
}
