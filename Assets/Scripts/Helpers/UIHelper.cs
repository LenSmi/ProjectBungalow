using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIHelper
{
    public static void LerpAddFillImage(Image fillImage, float toAdd, float max, float animDuration)
    {
        DOTween.Init();

        var addition = toAdd / max;
        var finalAmount = fillImage.fillAmount + addition;
        fillImage.DOFillAmount(finalAmount, animDuration);
    }

    public static void LerpReduceFillImage(Image fillImage, float toReduce, float max, float animDuration)
    {
        DOTween.Init();

        var reduction = toReduce / max;
        fillImage.DOFillAmount(reduction, animDuration);
    }
}
