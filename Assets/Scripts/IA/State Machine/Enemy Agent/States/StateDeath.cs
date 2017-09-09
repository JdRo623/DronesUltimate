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
        PlayDeathAnimation();
        /*me.SetActive(false);
          (me.GetComponent<BoxCollider>()).enabled = false;
          (me.GetComponent<CharacterController>()).enabled = false;*/
    }

    public override void OnUpdateAction()
    {
        time += Time.deltaTime;
        me.transform.Translate(-Vector3.up * 2.5f * Time.deltaTime);
        if (time>=5) {
            me.SetActive(false);
            (me.GetComponent<BoxCollider>()).enabled = false;
            (me.GetComponent<CharacterController>()).enabled = false;
        }

    }

    public override void OnExitAction()
    {
        (me.GetComponent<BoxCollider>()).enabled = true;
        (me.GetComponent<CharacterController>()).enabled = true;
    }
    public void PlayDeathAnimation() {
        // animator.SetTrigger("Walking2Death");
        me.SetActive(false);
    }
    public bool IsEnable2PursuitFromDeath() {
        return me.activeSelf;
    }
}
