using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoUIManager : MonoBehaviour
{

    private Cargo cargo;
    public Image fillImage;

    private float currentImageFillAmount;
    public float lerpAnimationNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentImageFillAmount = fillImage.fillAmount;
        cargo = FindObjectOfType<Cargo>();

        Cargo.AddItemsToCargo += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        
    }

    private void UpdateUI()
    {
        StartCoroutine(LerpAddFillImage(lerpAnimationNumber));
        Debug.Log("update ui");
    }



    public IEnumerator LerpAddFillImage(float animDuration)
    {
        float elapsedTime = 0f;
        currentImageFillAmount += cargo.previouslyAddedAmount;

        var finalFillAmount = currentImageFillAmount/ 10;

        while (elapsedTime < animDuration)
        {
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, finalFillAmount, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillImage.fillAmount = Mathf.Clamp(finalFillAmount,0,1f);

    }
}
