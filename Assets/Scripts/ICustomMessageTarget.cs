using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public interface ICustomMessageTarget : IEventSystemHandler
{
	// functions that can be called via the messaging system
	void OnStartGame();
}
