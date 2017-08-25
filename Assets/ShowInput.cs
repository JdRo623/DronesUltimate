using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowInput : MonoBehaviour {
    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("R2") > 0f)
        {
            text.text=("R2: " + Input.GetAxis("R2"));
        }
        if (Input.GetAxis("L2") == 1)
        {
            text.text = ("L2: " + Input.GetAxis("L2"));
        }
        if (Input.GetAxis("PSLeftJoystickX") > 0)
        {
            text.text = ("PSLeftJoystickX: " + Input.GetAxis("PSLeftJoystickX"));
        }
        if (Input.GetAxis("PSLeftJoystickX") < 0)
        {
            text.text = ("PSLeftJoystickX: " + Input.GetAxis("PSLeftJoystickX"));
        }
        if (Input.GetAxis("PSLeftJoystickY") > 0)
        {
            text.text = ("PSLeftJoystickY: " + Input.GetAxis("PSLeftJoystickY"));
        }
        if (Input.GetAxis("PSLeftJoystickY") < 0)
        {
            text.text = ("PSLeftJoystickY: " + Input.GetAxis("PSLeftJoystickY"));
        }
        if (Input.GetAxis("PSRigthJoystickY") < 0)
        {
            text.text = ("PSLeftJoystickY: " + Input.GetAxis("PSLeftJoystickY"));
        }
        if (Input.GetAxis("PSRigthJoystickY") > 0)
        {
            text.text = ("PSLeftJoystickY: " + Input.GetAxis("PSLeftJoystickY"));
        }
        if (Input.GetButtonDown("Y"))
        {
            text.text = ("Y: " + Input.GetAxis("Y"));
        }
        if (Input.GetButtonDown("A"))
        {
            text.text = ("A: " + Input.GetAxis("A"));
        }
        if (Input.GetButton("X"))
        {
            text.text = ("X: " + Input.GetAxis("X"));
        }
        if (Input.GetButton("B"))
        {
            text.text = ("B: " + Input.GetAxis("B"));
        }
    }
}
