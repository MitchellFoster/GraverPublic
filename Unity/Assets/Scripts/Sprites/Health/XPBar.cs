using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    Slider _xpSlider;

    private void Start()
    {
        _xpSlider = GetComponent<Slider>();
    }

    public void SetXP(int NextxpAmount)
    {
        _xpSlider.maxValue = NextxpAmount;
    }

    public void SetCurrentXP(int currentXP)
    {
        _xpSlider.value = currentXP;
    }
}
