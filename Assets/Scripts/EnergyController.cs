﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{

    public Slider energySlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energySlider.value = HamsterController.instance.currentEnergy;
    }
}
