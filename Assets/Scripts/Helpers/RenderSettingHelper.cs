using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RenderSettingHelper
{
    public static CustomRenderSettings GetRenderSettings()
    {
        CustomRenderSettings settings = new CustomRenderSettings();
        settings.enableFog = RenderSettings.fog;
        settings.fogColor = RenderSettings.fogColor;
        settings.fogMode = RenderSettings.fogMode;
        settings.fogDensity = RenderSettings.fogDensity;
        settings.fogStartDistance = RenderSettings.fogStartDistance;
        settings.fogEndDistance = RenderSettings.fogEndDistance;
        return settings;
    }
    public static void SetRenderSettings(CustomRenderSettings settings)
    {
        RenderSettings.fog = settings.enableFog;
        RenderSettings.fogColor = settings.fogColor;
        RenderSettings.fogMode = settings.fogMode;
        RenderSettings.fogDensity = settings.fogDensity;
        RenderSettings.fogStartDistance = settings.fogStartDistance;
        RenderSettings.fogEndDistance = settings.fogEndDistance;
    }

}
