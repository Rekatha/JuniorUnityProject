using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
	public static MainManager Instance { get; private set; }
	public Color TeamColor;
	public PlayerInformations PlayerInformations;

	private void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		LoadColor();
	}

	[System.Serializable]
	class SaveData
	{
		public Color TeamColor;
	}

	[System.Serializable]
	class PlayerInformationsData
	{
		public PlayerInformations PlayerInformations;
	}

	public bool DeletePlayerInfo()
	{
		string path = Application.persistentDataPath + "/playerinformations.json";
		if (File.Exists(path))
		{
			File.Delete(path);
			return true;
		}
		return false;
	}

	public void SaveColor()
	{
		SaveData data = new SaveData
		{
			TeamColor = TeamColor,
		};

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadColor()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			TeamColor = data.TeamColor;
		}
	}

	public void SavePlayerInformations()
	{
		PlayerInformationsData data = new PlayerInformationsData
		{
			PlayerInformations = PlayerInformations,
		};

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/playerinformations.json", json);
	}

	public bool LoadPlayerInformations()
	{
		string path = Application.persistentDataPath + "/playerinformations.json";
		if(File.Exists(path))
		{
			Debug.Log(path);
			string json = File.ReadAllText(path);

			PlayerInformationsData data = JsonUtility.FromJson<PlayerInformationsData>(json);
			PlayerInformations = data.PlayerInformations;

			return true;
		}
		return false;
	}
}
