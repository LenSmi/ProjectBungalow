using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIHelper
{
    public static void LerpAddFillImage(Image fillImage,float toAdd, float max, float animDuration)
    {
        DOTween.Init();

        var finalFillAmount = (fillImage.fillAmount += toAdd) / max;
        var clampedFillAmount = Mathf.Clamp(finalFillAmount, 0, 1f);

        fillImage.DOFillAmount(clampedFillAmount, animDuration);
    }

    public static void LerpReduceFillImage(Image fillImage, float toAdd, float max, float animDuration)
    {
        DOTween.Init();

        var finalFillAmount = toAdd / max;
        var clampedFillAmount = Mathf.Clamp(finalFillAmount, 0, 1f);

        fillImage.DOFillAmount(clampedFillAmount, animDuration);
    }
}
