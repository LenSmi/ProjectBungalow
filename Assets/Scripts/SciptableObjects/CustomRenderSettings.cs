using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RenderSettingsData", menuName = "ScriptableObjects/CustomRenderSettings")]
public class CustomRenderSettings : ScriptableObject
{
    public bool enableFog;
    public Color fogColor = Color.gray;
    public FogMode fogMode = FogMode.Linear;
    public float fogDensity = 0.01f;
    public float fogStartDistance = 10f;
    public float fogEndDistance = 100f;
    public float fogSettingLerpSpeed;
}
