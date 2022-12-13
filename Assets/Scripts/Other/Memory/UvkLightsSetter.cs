using System.Collections.Generic;

public class UvkLightsSetter 
{
    private Dictionary<string, int> _lights;
    public UvkLightsSetter(Dictionary<string, int> lights)
    {
        _lights = lights;
    }
    public void SetUvkLights()
    {
        _lights.Add("uvk_cpu_scpu1_light", 0);
        _lights.Add("uvk_cpu_scpu2_light", 0);
        _lights.Add("uvk_cpu_scpu3_light", 0);
        _lights.Add("uvk_cpu_mip2_light", 0);
        _lights.Add("uvk_cpu_mip3_light", 0);

        _lights.Add("uvk_uso1_sbs1_light", 0);
        _lights.Add("uvk_uso1_sbs2_light", 0);
        _lights.Add("uvk_uso1_mip2k_light", 0);
        _lights.Add("uvk_uso1_msi1k3_light", 0);
        _lights.Add("uvk_uso1_msi2k3_light", 0);
        _lights.Add("uvk_uso1_msi3k3_light", 0);
        _lights.Add("uvk_uso1_msi3k4_light", 0);
        _lights.Add("uvk_uso1_mvu1k2_light", 0);
        _lights.Add("uvk_uso1_mvu2k5_light", 0);
        _lights.Add("uvk_uso1_mbko1k2_light", 0);
        _lights.Add("uvk_uso1_mbko3k2_light", 0);
        _lights.Add("uvk_uso1_mbko2k3_light", 0);
        _lights.Add("uvk_uso1_mbko3k4_light", 0);
        _lights.Add("uvk_uso1_mbko2k5_light", 0);
    }
    public Dictionary<string, int> GetLights()
    {
        return _lights;
    }
}
