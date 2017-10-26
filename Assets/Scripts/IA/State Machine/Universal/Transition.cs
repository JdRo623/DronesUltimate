using UnityEngine;
using System.Collections;

public class Transition
{

	public SMAction action{get; set;}

	public State targetState{get; set;}

	public TestTransition IsTriggered{get; set;}

}
public delegate bool TestTransition();