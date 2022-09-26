using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDoorController : MonoBehaviour
{
	private CurrentDoorController(){}
	public static CurrentDoorController Instance;
	private �upboardDoor _currentDoor;
    private void Awake()
	{
		if(Instance==null)
			Instance = this;
	}
	public void SetCurrentDoor(�upboardDoor door)
	{
		_currentDoor = door;
	}
	public �upboardDoor GetCurrentDoor()
	{
		if (_currentDoor != null)
			return _currentDoor;
		else return null;
	}

}
