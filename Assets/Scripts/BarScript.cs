using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * skrypt napisany Przez Marcina Wieczorka
 */
public class BarScript : MonoBehaviour {
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 1, 0);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar(); 
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount){ 
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed); 
            // napełnianie, odejmowanie paska życia z efektem "smooth", możliwość określania predkości "smootha" przez wartość lerpSpeed w interfejsie unity
        }
        
    }

    private float Map(float value, float inMin, float inMax, float outMax, float outMin)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        /*
         value = faktyczne HP - wartość dynamiczna
         inMin/Max = minimalna i maksymalna wartość faktycznego HP, np. 0 i 100
         outMin/Max = minimala i maksymalna wartosc fillAmount z interfejsu unity, 0 i 1 (translacja)
         np. 80HP * 1 / 100 = 0.8 -> ustawi pasek wypełnienia na 80%
         */
    }
}
