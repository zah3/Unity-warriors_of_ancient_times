using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * skrypt napisany przez Zachariasza Staniszewskiego
 * Zmiana poziomów.
 */
public class LevelMenager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Application.LoadLevel(name);
    }
    public void Quit()
    {
        Debug.Log("I wont a quit");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
