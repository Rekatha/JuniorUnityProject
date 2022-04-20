using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;


	private string playerInformationsJsonPath = "";

	public void NewColorSelected(Color color)
    {
		// add code here to handle when a color is selected
		MainManager.Instance.TeamColor = color;
    }
	private void Awake()
	{
		playerInformationsJsonPath = Application.persistentDataPath + "/playerinformations.json";
	}

	private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
		ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

	public void StartNew()
	{
		if(File.Exists(playerInformationsJsonPath))
		{
			SceneManager.LoadScene(2);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}

	public void Exit()
	{
		MainManager.Instance.SaveColor();
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}

	public void DeletePlayerInfo()
	{
		MainManager.Instance.DeletePlayerInfo();
	}

	public void SaveColorClicked()
	{
		MainManager.Instance.SaveColor();
	}

	public void LoadColorClicked()
	{
		MainManager.Instance.LoadColor();
		ColorPicker.SelectColor(MainManager.Instance.TeamColor);
	}
}
