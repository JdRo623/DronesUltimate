using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerHealt : MonoBehaviour,Health {

    private float player_health_min = 0;   // min health
    public float player_health = 100;      // curent health
    private float timeout = 0;             // timer
    public float fire_damage = 1;           // fire damage
    public int bullet_damage; // bullet damage
    public int melee_damage = 1;// melee atack damage
    public GameObject camera;
    public Slider healtSlider;
   
    void Start()
    {
        InitHealt();
        healtSlider.minValue = 0;
        healtSlider.maxValue = player_health;
    }
    void Update()
    {

        healtSlider.value = player_health;


        if (player_health <= player_health_min)// if curent health <= min health
        {
            if (!gameObject.GetComponent<Rigidbody>())// if fpc hasn't rigidbody
            {
                gameObject.GetComponent<Health_BlackTexture>().change_speed = 1;// draw black texture
                camera.GetComponent<Animation>().Play("Die");// the animation play "Die"
                timeout += Time.deltaTime;// timer active
                if (timeout >= 5)// after 1 second
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
            player_health = player_health_min;// curent health = min health

        }
    }
    public void ReciveDamage(float damage) {
        player_health -= damage;
    }

    public void ReciveHealt(int add_health)
    {
        player_health += add_health;
    }

    public void InitHealt()
    {
        player_health = GameHandler.playerInitLife;
    }

    public float GetCurrentHealt()
    {
        throw new NotImplementedException();
    }

    public void Died()
    {
        throw new NotImplementedException();
    }
}
