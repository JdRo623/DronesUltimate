using UnityEngine;
using System.Collections;
using System;

public class GiveHealtHandler : MonoBehaviour {

    float time = 0;
    public float inTimeStay;
    public HUDHandler hudHandler;
    public int cost;
    public bool isAmmo;
    public AudioSource audioSource;
    public AudioClip validSound;
    public AudioClip noValidSound;
    private bool isEnableTo = true;
    public void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && isEnableTo) {
            time += Time.deltaTime;
            hudHandler.SetMaxProggresBar(inTimeStay);
            if (inTimeStay <= time){
                    UpdateHealt(other.gameObject);
                
            }else if (inTimeStay > time) {
                hudHandler.UpdateProggresBar(time);
            }
        }
    }


    public void OnTriggerExit()
    {
        time = 0;
        isEnableTo = true;
    }
    private void ValidSound() {
        audioSource.clip = validSound;
        audioSource.Play();
    }
    private void NoValidSound() {
        audioSource.clip = noValidSound;
        audioSource.Play();
    }
    private void UpdateHealt(GameObject player){
        if (PlayerScoreHandler.score >= cost)
        {
            PlayerScoreHandler.score -= cost;
            PlayerLife pl = player.GetComponent<PlayerLife>();
            hudHandler.lifePanel.SetActive(true);
            pl.RestoreHealt();
            ValidSound();
            isEnableTo = false;
        }
        else {
            NoValidSound();
        }
    }
}
