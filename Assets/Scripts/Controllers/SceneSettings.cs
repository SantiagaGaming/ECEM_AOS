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
        _memory.CurrentLocation = "Start";
        _memory.StrelkPosition = true;
        _memory.Stone = false;
        _memory.Teleport = false;
        _memory.PrevousLocation = "";
        _memory.LocationText = "";
        _memory.ScpuBroken = false;
        _memory.LampLights = 0;
        _memory.QfCondition = false;
        _memory.DspShvuKey0 = false;
        _memory.DspShvuKey3 = false;
        _memory.KnifePosition= 0;
        _memory.Monitor1 = true;
        _memory.Monitor2 = true;
        _memory.Monitor3 = false;
        _memory.Monitor1Enabler = true;
        _memory.UvkLights = new Dictionary<string, int>();
        FillUvkLights();
    }
    private void FillUvkLights()
    {
        _memory.UvkLights.Add("uvk_cpu_scpu1_light", 0);
        _memory.UvkLights.Add("uvk_cpu_scpu2_light", 0);
        _memory.UvkLights.Add("uvk_cpu_scpu3_light", 0);
        _memory.UvkLights.Add("uvk_cpu_mip2_light", 0);
        _memory.UvkLights.Add("uvk_cpu_mip3_light", 0);
        _memory.UvkLights.Add("uvk_uso1_sbs1_light", 0);
        _memory.UvkLights.Add("uvk_uso1_sbs2_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mip2k_light", 0);
        _memory.UvkLights.Add("uvk_uso1_msi1k3_light", 0);
        _memory.UvkLights.Add("uvk_uso1_msi2k3_light", 0);
        _memory.UvkLights.Add("uvk_uso1_msi3k3_light", 0);
        _memory.UvkLights.Add("uvk_uso1_msi3k4_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mvu1k2_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mvu2k5_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mbko1k2_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mbko3k2_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mbko2k3_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mbko3k4_light", 0);
        _memory.UvkLights.Add("uvk_uso1_mbko2k5_light", 0);
    }
}
