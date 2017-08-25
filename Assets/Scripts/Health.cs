using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	private float player_health_min = 0;   // min health
    public float player_health = 100;      // curent health
    private float timeout = 0;             // timer
    public GUIText HP;                     // text which shows the current health
	public float fire_damage = 1;           // fire damage
	public int explosition_damage = 4;     // explosion damage
	public int bullet_damage; // bullet damage
	public int melee_damage=1;// melee atack damage
	public GameObject camera;
    public Slider healtSlider;

    void Start()
    {
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
    public void Del()// explosion damage
    {
        player_health -= explosition_damage;// curent health - explosion damage
    }

    public void damage(float harm) {
        player_health -= harm;
    }

   void OnTriggerStay(Collider Col)// fire damage
    {
        if (Col.tag == "Fire")// if collider tag = "fire'
        {
            player_health -= fire_damage;// curent health - fire damage
        }
    }



    void OnGUI()// draw curent health
    {
        HP.text = "" + Mathf.Round(player_health);
    }
}

