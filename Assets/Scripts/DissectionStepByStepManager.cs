using System;
using UnityEngine;
using UnityEngine.UI;

public class DissectionStepByStepManager : MonoBehaviour
{
    // PLAN:
    // Firstly start by getting the student to identify the sex of the mouse.
    /* 	- Then you want them to pin the limbs.
        - Then make the first incision.
        - Then with each step of the booklet follow along */
    // With these steps I need different tools to use at each step, different UI to display and a reference to the interactive objects

    public int currentStep = 0; // Tracks the current step
    public GameObject[] stepsUI; // UI elements for step instructions
    public ClickableObject[] interactiveObjects; // Clickable organs or body parts

    public void Start()
    {
        UpdateStep();
        interactiveObjects = FindObjectsByType<ClickableObject>(FindObjectsSortMode.None);
    }
    public void AdvanceStep()
    {
        if (currentStep < stepsUI.Length - 1)
        {
            currentStep++;
            UpdateStep();
        }
    }

    private void UpdateStep()
    {
        // Show only the current step UI
        for (int i = 0; i < stepsUI.Length; i++)
        {
            stepsUI[i].SetActive(i == currentStep);
        }
    }

}
