using UnityEngine;
using System.Collections;

public class StateDeath : State {
    public GameObject me;
    private float time;
    private Animator animator;
    public override void OnEntryAction()
    {
        animator = me.GetComponent<Animator>();
        time = 0;
        /*me.SetActive(false);
          (me.GetComponent<BoxCollider>()).enabled = false;
          (me.GetComponent<CharacterController>()).enabled = false;*/
    }

    public override void OnUpdateAction()
    {
        time += Time.deltaTime;
        me.transform.Translate(-Vector3.up * 0.2f * Time.deltaTime);
        (me.GetComponent<UnityEngine.AI.NavMeshAgent>()).enabled = false;
        (me.GetComponent<BoxCollider>()).enabled = false;
        (me.GetComponent<CharacterController>()).enabled = false;
        if (time >= 5) {
            (me.GetComponent<UnityEngine.AI.NavMeshAgent>()).enabled = true;
            (me.GetComponent<BoxCollider>()).enabled = true;
            (me.GetComponent<CharacterController>()).enabled = true;
            me.SetActive(false);
        }

    }

    public override void OnExitAction()
    {
       
    }
    public bool IsEnable2PursuitFromDeath() {
        return !me.activeSelf;
    }
}
