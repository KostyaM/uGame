﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, HealthPreview
{
    public void setHealth(int value, int full)
    {
        gameObject.GetComponent<Slider>().SetValueWithoutNotify((float)value / (float)full);
    }

}
