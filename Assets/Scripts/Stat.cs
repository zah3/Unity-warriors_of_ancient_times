using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * skrypt napisany Przez Marcina Wieczorka
 */
[Serializable]
public class Stat {

    [SerializeField] //umozliwienie nadawania wartosci dla pól prywatnych w interfejsie unity
    private BarScript bar;

    [SerializeField]
    private float maxVal;  //maksymalna wartość health

    [SerializeField]
    private float currentVal; //obecna wartość health

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal); //ograniczenie dodawania i odejmowania HP od 0 do MaxVal
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = value;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
