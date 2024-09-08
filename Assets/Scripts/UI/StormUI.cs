using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StormUI : MonoBehaviour
{
    public Image StormOverlay;
    public float DesiredAlpha;
    private Color _stormOverlayAlpha;

    // Start is called before the first frame update
    void Start()
    {
        _stormOverlayAlpha = StormOverlay.color;
        _stormOverlayAlpha.a = 0;
        StormOverlay.color = _stormOverlayAlpha;
        MinigameManager.StormStarted += UpdateStormUI;
    }

    void UpdateStormUI()
    {
        _stormOverlayAlpha = StormOverlay.color;
        _stormOverlayAlpha.a = DesiredAlpha;
        StormOverlay.color = _stormOverlayAlpha;
    }

    private void OnDestroy()
    {
        MinigameManager.StormStarted -= UpdateStormUI;
    }

}
