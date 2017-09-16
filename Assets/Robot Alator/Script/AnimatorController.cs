using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float y;
		y=Input.GetAxis("Vertical");
		animator.SetFloat ("Vertical", y);

		float x;
		x=Input.GetAxis("Horizontal");
		animator.SetFloat ("Horizontal", x);
	}
}
