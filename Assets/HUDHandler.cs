using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUDHandler : MonoBehaviour {
    public  GameObject objectivePanel;
    public GameObject lifePanel;
    public GameObject progressBarPanel;
    public GameObject gunPanel;
    public GameObject deathPanel;
    private float lifePanelTime;
    private float objectivePanelTime;
    private float proggresBarTime;
    public GameObject mira;

    public Text objectivePanelText;
    public Slider lifePanelSlider;
    public Slider progressBarSlider;

    void Awake() {
        objectivePanel.SetActive(false);
        progressBarPanel.SetActive(false);

        lifePanelTime = 0;
        objectivePanelTime = 0;
        proggresBarTime = 0;

        objectivePanelText = objectivePanel.GetComponentInChildren<Text>();
        lifePanelSlider = lifePanel.GetComponentInChildren<Slider>();
        progressBarSlider = progressBarPanel.GetComponentInChildren<Slider>();
    }

    void Update() {
        checkActivationOfObjectivePanel();
        checkActivationOfProggresBar();
    }

    public void SetMaxProggresBar(float max) {
        progressBarSlider.maxValue = max;
    }
    public void UpdateProggresBar(float proggres) {
        progressBarPanel.SetActive(true);
        progressBarSlider.value = proggres;
    }
    private void checkActivationOfLifePanel() {
        if (lifePanel.active==true) {
            lifePanelTime += Time.deltaTime;
            if (lifePanelTime >= 5)
            {
                lifePanel.SetActive(false);
                lifePanelTime = 0;
            }
        }

    }

    internal void setDeathScreen()
    {
        deathPanel.SetActive(true);
    }

    private void checkActivationOfProggresBar()
    {
        if (progressBarPanel.active == true)
        {
            proggresBarTime += Time.deltaTime;
            if (proggresBarTime >= 1)
            {
                progressBarPanel.SetActive(false);
                proggresBarTime = 0;
            }
        }

    }

    public void refreshObjectiveHUD(string objective){
        objectivePanel.SetActive(true);
        objectivePanelText.text = objective;
    }
    public void refreshLifeBar(float currentLife) {
        lifePanelSlider.value = currentLife;
    }

    public void refreshAmmoText(int chamber, int total) {
        Text[] texts = gunPanel.GetComponentsInChildren<Text>();
        texts[0].text = chamber+""; 
    }
    private void checkActivationOfObjectivePanel() {
        if (objectivePanel.active == true) {
            objectivePanelTime += Time.deltaTime;
            if (objectivePanelTime >= 4) {
                objectivePanel.SetActive(false);
                objectivePanelTime = 0;
            }
        }

    }

    internal void setMiraOff()
    {
        mira.SetActive(!mira.active);
    }
}
