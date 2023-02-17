﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;
	public void PlayMaze()
	{
		SceneManager.LoadScene("maze");
		 if (colorblindMode != null && colorblindMode.isOn)
    	{
        trapMat.color = new Color32(255, 112, 0, 1);
        goalMat.color = Color.blue;
    	}
	}

    public void QuitMaze()
    {
        #if UNITY_EDITOR
        Debug.Log("Quit Game");
        #else
        Application.Quit();
        #endif
    }
}
