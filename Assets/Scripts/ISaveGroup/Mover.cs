using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, ISaveable
{
	[System.Serializable]
	public struct SaveData
	{
		public Vector2 position;
	}
	private Vector2 lastSavedPosition;
	private Rigidbody2D rigidBody2D;

	private void Awake()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	public void OnLoad(string data)
	{
		SaveData saveData = JsonUtility.FromJson<SaveData>(data);
		Vector2 newPosition = saveData.position;

		this.transform.position = newPosition;

		if (rigidBody2D != null && rigidBody2D.bodyType != RigidbodyType2D.Static)
		{
			rigidBody2D.MovePosition(newPosition);
		}
		lastSavedPosition = newPosition;
	}

	public string OnSave()
	{
		lastSavedPosition = this.transform.position;

		return JsonUtility.ToJson(new SaveData()
		{
			position = lastSavedPosition
		});
	}

	public bool OnSaveCondition()
	{
		return lastSavedPosition != (Vector2)this.transform.position;
	}
}
