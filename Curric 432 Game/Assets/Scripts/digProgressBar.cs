using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Progress Bar code
*/
public class digProgressBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxValue(float value) {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetValue(float value) {
        slider.value = value;
    }

}
