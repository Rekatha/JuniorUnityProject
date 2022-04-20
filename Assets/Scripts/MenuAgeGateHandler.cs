using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAgeGateHandler : MonoBehaviour
{
	public TMP_InputField NameInput;
	public TMP_Dropdown GenderDropDown;
	public TMP_InputField AgeInput;

	public void OnConfirmButton()
	{
		string gender = OnGenderDropDownValueChange();
		PlayerInformations data = new PlayerInformations
		{
			Name = NameInput.text,
			Gender = gender,
			Age = Int32.Parse(AgeInput.text)
		};
		MainManager.Instance.PlayerInformations = data;
		MainManager.Instance.SavePlayerInformations();
		SceneManager.LoadScene(2);
	}

	public string OnGenderDropDownValueChange()
	{
		switch (GenderDropDown.value)
		{
			case 0:
				{
					return "Unknown";
				}
			case 1:
				{
					return "Male";
				}
			case 2:
				{
					return "Female";
				}
		}
		return "Unknown";
	}
}
