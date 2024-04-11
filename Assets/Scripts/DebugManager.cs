using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public GUIStyle customStyle;

    private MouseController mouseController;


    private void Start()
    {
        mouseController = FindObjectOfType<MouseController>();    
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100),(1.0f / Time.smoothDeltaTime).ToString("F1"), customStyle);
        GUI.Label(new Rect(0, 30, 100, 100), mouseController.lastLayerhit, customStyle);
    }


}
