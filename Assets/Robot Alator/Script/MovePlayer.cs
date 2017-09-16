using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	private GameObject Player;

	public static int speed = 5;
	public static int _speed;
	public int rotation = 250;
	public static float x = 0.0f;

	void Start () {
		_speed = speed;
		Player = (GameObject)this.gameObject;
	}
	

	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			Player.transform.position += Player.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			Player.transform.position -= Player.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) { 
			Player.transform.position -= Player.transform.right * speed * Time.deltaTime;  
		} 
		if (Input.GetKey (KeyCode.D)) { 
			Player.transform.position += Player.transform.right * speed * Time.deltaTime;
		}
		Quaternion rotate = Quaternion.Euler (0, x, 0);  
		Player.transform.rotation = rotate;
	}
}



			



	

