﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_button1 : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Выход");
    }

}
