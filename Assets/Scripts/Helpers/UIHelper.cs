using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIHelper
{
    public static IEnumerator LerpReduceFillImage(Image fillImage, float currentFillAmount , float fillReduction, float animDuration)
    {
        float elapsedTime = 0f;

        currentFillAmount -= fillReduction;

        var finalFillAmount = currentFillAmount/ 100;

        while (animDuration >= elapsedTime)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, finalFillAmount, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillImage.fillAmount = Mathf.Clamp(finalFillAmount, 0.0f, 1);
    }

    public static IEnumerator LerpAddFillImage(Image fillImage, float currentFillAmount, float fillAddition, float animDuration)
    {
        float elapsedTime = 0f;

        currentFillAmount += fillAddition;

        var finalFillAmount = currentFillAmount / 10;

        while (animDuration >= elapsedTime)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, finalFillAmount, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillImage.fillAmount = Mathf.Clamp(finalFillAmount, 0.0f, 1);

        currentFillAmount = finalFillAmount;

        yield return currentFillAmount;
    }
}
