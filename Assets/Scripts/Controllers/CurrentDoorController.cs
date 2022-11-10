using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDoorController : MonoBehaviour
{
	private CurrentDoorController(){}
	public static CurrentDoorController Instance;
	private UVKDoorAnimation _currentDoor;
    private void Awake()
	{
		if(Instance==null)
			Instance = this;
	}
	public void SetCurrentDoor(UVKDoorAnimation door)
	{
		_currentDoor = door;
	}
	public UVKDoorAnimation GetCurrentDoor()
	{
		if (_currentDoor != null)
			return _currentDoor;
		else return null;
	}

}
