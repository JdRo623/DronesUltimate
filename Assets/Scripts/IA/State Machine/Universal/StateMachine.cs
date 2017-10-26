using UnityEngine;
using System.Collections;

public class StateMachine 
{
	public State[] states;
	private State initialState;
	private State currentState ;

	public StateMachine(State initState){
		initialState= initState;
		currentState = initState;
	}
	public SMAction Update(){
		SMAction actions =null;
		Transition triggeredTransition = null;

		foreach(Transition transition in currentState.transitions){
			if(transition.IsTriggered()){
				triggeredTransition=transition;
				break;
			}
		}
		if(triggeredTransition != null){
			State targetState = triggeredTransition.targetState;

			actions += currentState.OnExitAction;
			actions += triggeredTransition.action;
			actions += targetState.OnEntryAction;
			currentState = targetState;

		}else{
			actions += currentState.OnUpdateAction;
		}
		return actions;
	}
}
public delegate void SMAction();
