using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public GUIStyle CustomStyle;

    private MouseController _mouseController;
    private CargoManager _cargo;


    private void Start()
    {
        //mouseController = FindObjectOfType<MouseController>();
        _cargo = GameManager.Instance().CargoManager();
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
        GUI.Label(new Rect(0, 0, 200, 200),(1.0f / Time.smoothDeltaTime).ToString("F1"), CustomStyle);
        //GUI.Label(new Rect(0, 30, 200, 200), mouseController.lastLayerhit, customStyle);
        GUI.Label(new Rect(0, 60, 200, 200), SubStateManager.currentSubState.ToString(), CustomStyle);
#endif
    }


}
