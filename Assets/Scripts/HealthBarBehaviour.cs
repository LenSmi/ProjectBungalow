using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{

    public Image fillImage;
    public float maxHealthFillAmount = 100f;
    [HideInInspector]
    public float currentHealthFillAmount;

    private Camera mainCamera;

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealthFillAmount = maxHealthFillAmount;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up);
    }

    public IEnumerator LoseHealth(float animDuration, float lossAmount)
    {
        float elapsedTime = 0f;

        currentHealthFillAmount -= lossAmount;

        var finalFillAmount = currentHealthFillAmount / 100;

        while (animDuration >= elapsedTime)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, finalFillAmount, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillImage.fillAmount = Mathf.Clamp(finalFillAmount, 0.0f, 1);
    }
}
