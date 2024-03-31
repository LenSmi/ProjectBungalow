using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{

    public Image fillImage;
    public float healthFillAmont = 1f;
    [HideInInspector]
    public float currentHealthFillAmount;

    private Camera mainCamera;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealthFillAmount = healthFillAmont;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up);
    }

    public void LoseHealth(float animDuration, float targetAmount)
    {
        float elapsedTime = 0f;

        while (animDuration >= elapsedTime)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetAmount, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
        }

        fillImage.fillAmount = targetAmount;
    }
}
