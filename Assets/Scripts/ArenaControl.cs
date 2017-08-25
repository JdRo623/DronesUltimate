using UnityEngine;
using System.Collections;

public class ArenaControl : MonoBehaviour
{
    public GameObject robot1;// the first wave of robots
	public GameObject robot2;// the second wave of robots
	public GameObject robot3;// the third wave of robots
	public GameObject robot4;// the fourth wave of robots
	public GameObject robot5;// the fifth wave of robots
	public GameObject robot6;// the sixth wave of robots
    public bool _null = false; // reset progress

	void Start(){

		if (PlayerPrefs.GetInt("Score") == 0)// if score=0 
		{
			robot1.SetActive(true); // activate w1(the first wave of robots)
		}

		if (PlayerPrefs.GetInt("Score") == 1)//if score=1 
		{

			robot1.SetActive(false);//  deactivate w1(the first wave of robots)
			robot2.SetActive(true);//   activate w2(the second wave of robots)
		}

		if (PlayerPrefs.GetInt("Score") == 2)// if score=2
		{

			robot1.SetActive(false);//  deactivate w1
			robot2.SetActive(false);//  deactivate w2
			robot3.SetActive(true);//   activate w3
		}
		if (PlayerPrefs.GetInt("Score") == 3)// if score=3
		{

			robot1.SetActive(false);//  deactivate w1
			robot2.SetActive(false);//  deactivate w2
			robot3.SetActive(false);//  deactivate w3
			robot4.SetActive(true); //  activate w4

		}
		if (PlayerPrefs.GetInt("Score") == 4)// if score=4
		{

			robot1.SetActive(false);//  deactivate w1
			robot2.SetActive(false);//  deactivate w2
			robot3.SetActive(false);//  deactivate w3
			robot4.SetActive(false);//  deactivate w4
			robot5.SetActive(true); //  activate w5
		}

		if (PlayerPrefs.GetInt("Score") == 5)// if score=5
		{

			robot1.SetActive(false);//  deactivate w1
			robot2.SetActive(false);//  deactivate w2
			robot3.SetActive(false);//  deactivate w3
			robot4.SetActive(false);//  deactivate w4
			robot5.SetActive(false); // deactivate w5
			robot6.SetActive(true); //  activate w6
		}

	}

    void Update()
    {

		if (_null == true)// if reset progress then score =0;
        {
            PlayerPrefs.SetInt("Score", 0);
        }

        if (PlayerPrefs.GetInt("Score") == 0)// if score=0 
        {
			robot1.SetActive(true); // activate w1(the first wave of robots)
        }

        if (PlayerPrefs.GetInt("Score") == 1)//if score=1 
        {
			
			robot2.SetActive(true);//   activate w2(the second wave of robots)
        }

        if (PlayerPrefs.GetInt("Score") == 2)// if score=2
        {
			robot3.SetActive(true);//   activate w3
        }
        if (PlayerPrefs.GetInt("Score") == 3)// if score=3
        {
			robot4.SetActive(true); //  activate w4
        }
        if (PlayerPrefs.GetInt("Score") == 4)// if score=4
        {


			robot5.SetActive(true); //  activate w5
        }

		if (PlayerPrefs.GetInt("Score") == 5)// if score=5
		{


			robot6.SetActive(true); //  activate w6
		}

    }
}

