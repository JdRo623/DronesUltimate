using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1Objectives : MonoBehaviour {
    private static Level1Objectives instance = new Level1Objectives();
    private List <string> objetives = new List<string>();
    private int currentObjective=0;
    public Level1Objectives() {
        initObjectives();
        Debug.Log(objetives[0]);
    }
    public static Level1Objectives getInstance() {
        return instance;
    }

    public void setNextObjective() {
        currentObjective++;
        Debug.Log(objetives[currentObjective]);
    }
    public string getNextObjective() {
        return objetives[currentObjective];
    }
    private void initObjectives() {
        objetives.Add("Find a Gun");
        objetives.Add("Find an exit");
        objetives.Add("Find a whatever");
        
    }
}

