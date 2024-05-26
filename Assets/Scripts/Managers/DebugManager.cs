using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public GUIStyle customStyle;

    private MouseController mouseController;
    private Cargo cargo;


    private void Start()
    {
        mouseController = FindObjectOfType<MouseController>();
        cargo = GameManager.Instance().cargo();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 200),(1.0f / Time.smoothDeltaTime).ToString("F1"), customStyle);
        GUI.Label(new Rect(0, 30, 200, 200), mouseController.lastLayerhit, customStyle);
        GUI.Label(new Rect(0, 60, 200, 200), SubStateManager.currentSubState.ToString(), customStyle);

    }


}
