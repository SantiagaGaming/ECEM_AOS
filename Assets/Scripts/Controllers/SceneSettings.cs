using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public static SceneSettings Instance;
    public bool CanTouch { get; set; } = true;
    public ProjectMemory Memory => _memory;

    [SerializeField] private ProjectMemory _memory;
    public string LocationName { get; private set; }
    private SceneSettings() { }

    private void Awake()
    {
        if(Instance==null)
            Instance = this;
        LocationName = SceneManager.GetActiveScene().name;
    }
public void SetMemory()
    {
        _memory.StrelkPosition = true;
        _memory.Stone = false;
        _memory.Teleport = false;
        _memory.PrevousLocation = "";
        _memory.LocationText = "";
        _memory.ScpuBroken = false;
        _memory.LampLights = 0;
        _memory.QfCondition = false;
}
}
