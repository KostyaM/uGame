using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPreviewText : MonoBehaviour, HealthPreview
{

    public TextMeshProUGUI text;
    public void setHealth(int value, int full)
    {
       text.text = $"HP {value}";
    }
}
