using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat 
{
    [SerializeField]
    BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    private float percentVal;

    public void setVal(float val)
    {
        currentVal = val;
        if (currentVal > maxVal)
        {
            currentVal = maxVal;
        }
        if (currentVal < 0)
        {
            currentVal = 0;
        }
        percentVal = currentVal / maxVal;
        bar.setVal(percentVal);
    }

    public float getVal()
    {
        return currentVal;
    }

    public void Initialize()
    {
        setVal(currentVal);
    }
    }
