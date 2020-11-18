using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace anogame
{
	public class SaveSystem : MonoBehaviour
	{
		[SerializeField]
		private SaveGame cachedSaveData;

		[SerializeField]
		private SaveEvent onGameSave;

		[SerializeField]
		private SaveEvent onGameLoad;

		[SerializeField]
		private IntReference saveSlot;

		private void Start()
		{
			cachedSaveData = SaveUtility.LoadSave(saveSlot.Value);
			if (cachedSaveData == null)
			{
				Debug.Log("cachedSaveData == null");
				CreateNewSave();
			}

			onGameLoad?.Invoke(cachedSaveData);
		}
		private void CreateNewSave()
		{
			cachedSaveData = new SaveGame();

			/*
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene getScene = SceneManager.GetSceneAt(i);

				if (getScene.name != "Core")
				{
					cachedSaveData.lastScene = getScene.name;
					cachedSaveData.playerName = playerName.Value;
					cachedSaveData.farmName = farmName.Value;
				}
			}
			*/
			WriteSaveToFile();
		}


		public void OnLoadSystem()
		{
			cachedSaveData = SaveUtility.LoadSave(saveSlot.Value);
		}

		public void Initialize()
		{
			cachedSaveData = SaveUtility.LoadSave(saveSlot.Value);
		}

		public void Save()
		{
			onGameSave?.Invoke(cachedSaveData);

			WriteSaveToFile();
		}

		public void Load()
		{
			onGameLoad?.Invoke(cachedSaveData);
		}

		private void WriteSaveToFile()
		{
			TimeSpan currentTimePlayed = DateTime.Now - cachedSaveData.saveDate;
			TimeSpan allTimePlayed = cachedSaveData.timePlayed;
			cachedSaveData.timePlayed = allTimePlayed + currentTimePlayed;

			SaveUtility.WriteSave(cachedSaveData, saveSlot.Value);
		}

	}
}
