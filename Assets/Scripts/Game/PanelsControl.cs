using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    public GameObject levelsPanel;
    public GameObject controlsguidePanel;
    public GameObject objectivesPanel;

    // List of levels
    public void ShowLevels()
    {
        levelsPanel.SetActive(true);
    }
    public void HideLevels()
    {
        levelsPanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 0) 
        {
            controlsguidePanel.SetActive(true);
            objectivesPanel.SetActive(true);
        }
        else
        {
            controlsguidePanel.SetActive(false);
            objectivesPanel.SetActive(false);
        }
    }
    // Controls guide


    // Objectives
}
