using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat health; //health Bar, aby dodac np. energy, shield nalezy dodac: private Stat energy

    private void Awake()
    {
        health.Initialize(); //inicjalizacja paska health, mozliwe dodanie np. mana, energy, shield: energy.Initialize();
    }

    // Use this for initialization
    void Start () { 

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D)) // DAMEGE
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.H)) //HEALTH
        {
            health.CurrentVal += 5;
        }
    }
}
