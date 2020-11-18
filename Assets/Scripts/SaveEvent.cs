using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace anogame
{
	[CreateAssetMenu(menuName = "Events/Save Event")]
	public class SaveEvent : ScriptableEvent<SaveGame>
	{
	}
}
