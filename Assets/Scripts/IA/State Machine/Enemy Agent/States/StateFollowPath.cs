using UnityEngine;
using System.Collections;

public class StateFollowPath : State
{
    public Transform[] goals;
  //  public Transform enemy;
    public Transform myTransform;
    public float speed;
    private Vector3 direcction;
    public int selectedGoal;
    private Transform goal;
    private bool thereAreGoals;
    private int currentGoal;
    private EnemyHealth myHealt;
    private bool isDead;
    public override void OnEntryAction()
    {
        goal = goals[0];
        thereAreGoals = true;
        currentGoal = 0;
        myHealt = myTransform.GetComponent<EnemyHealth>();
        isDead = false;
    }

    public override void OnUpdateAction()
    {
        Debug.Log("Esta siguiendo un camino");
        if (myHealt.currentHealth <= 0)
        {
            isDead = true;
        }
        if (thereAreGoals)
        {
            direcction = (goal.position - myTransform.position);
            direcction.Normalize();
            direcction *= speed;
            direcction *= Time.deltaTime;
            myTransform.position += direcction;
            transformRotation();
            if ((currentGoal++) != goals.Length)
            {
                goal = goals[currentGoal];
            }
            else {
                thereAreGoals = false;
            }
        }

    }

    public override void OnExitAction()
    {

    }
    public void transformRotation()
    {
        float orientation = Mathf.Atan2(direcction.x, direcction.z);
        orientation *= Mathf.Rad2Deg;
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(0, orientation, 0);
        myTransform.rotation = newRotation;
    }
    public bool itHasEndItsPath()
    {
        return !thereAreGoals;
    }
    public bool ImDead()
    {
        return isDead;
    }
}
