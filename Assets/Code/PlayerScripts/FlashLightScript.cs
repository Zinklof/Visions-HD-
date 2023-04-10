using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    [Header("flashlight lights")]
    public Light lightOne;
    public Light lightTwo;

    [Header("Battery Modifiers")]
    public float drainRate;
    public float regenRate;
    public bool flashLightOn;

    [Header("Lights")]
    public float lightOneIntensity;
    public float lightTwoIntensity;

    [Header("UI Elements")]
    public Image flashlightBarUi = null;
    public CanvasGroup flashlightCanvasGroup = null;

    private float flashLightMaxBattery = 100f;
    private float flashLightBattery = 100f;
    private float delay = 0f;

    // drains battery while on or regens while off
    private void DrainBattery()
    {
        if (flashLightOn)
            flashLightBattery -= drainRate;
        else
            flashLightBattery += regenRate;
    }

    private void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && !flashLightOn && delay <=0)
        {
            flashLightOn = true;
            lightOne.range = lightOneIntensity;
            lightTwo.range = lightTwoIntensity;
            delay = 1f;
        }

        if (Input.GetKeyDown(KeyCode.F) && flashLightOn && delay <= 0)
        {
            flashLightOn = false;
            lightOne.range = 0f;
            lightTwo.range = 0f;
            delay = 1f;
        }
    }

    // resets values if they get too high or low
    private void ResetValues()
    {
        if (flashLightBattery <= 0f)
        {
            flashLightBattery = 0f;
        }
        if (flashLightBattery >= flashLightMaxBattery)
        {
            flashLightBattery = flashLightMaxBattery;
        }
    }

    // changes intensity of lights when off or on
    private void LightIntensity()
    {
        if (flashLightOn)
        {
            lightOne.range = lightOneIntensity;
            lightTwo.range = lightTwoIntensity;
        }
        else
            lightOne.range = 0f;
            lightTwo.range = 0f;
    }

    private void CanvasGroup()
    {
        if (flashLightBattery > 99.99f)
        {
            flashlightCanvasGroup.alpha = 0f;
        }
        else
            flashlightCanvasGroup.alpha = 0.25f;
    }

    private void BarUi()
    {
        flashlightBarUi.fillAmount = flashLightBattery / flashLightMaxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        DrainBattery();
        ToggleLight();
        ResetValues();
        //LightIntensity();
        CanvasGroup();
        BarUi();
        delay -= 0.1f;

        // turns off when battery is dead
        if (flashLightBattery <= 0.5f)
        {
            flashLightOn = false;
            lightOne.range = 0f;
            lightTwo.range = 0f;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }
}