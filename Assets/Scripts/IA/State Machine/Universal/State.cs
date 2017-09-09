using UnityEngine;
using System.Collections;

public class State
{
	public Transition[] transitions{set; get;}

	public virtual void OnEntryAction(){

	}
	public virtual void OnUpdateAction(){

	}
	public virtual void OnExitAction(){

	}

}

