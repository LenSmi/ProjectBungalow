using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

        Cargo.AddItemsToCargo += UpdateAddFillUi;
        Cargo.AddItemsToDeposit += UpdateReduceFillUi;
    }
    private void Init()
    {
        
    }

    private void UpdateAddFillUi()
    {
        UIHelper.LerpAddFillImage(fillImage, cargo.previouslyAddedAmount, cargo.maxCargo, lerpAnimationNumber);
    }

    private void UpdateReduceFillUi()
    {
        UIHelper.LerpAddFillImage(fillImage, cargo.subCargoInventory.Values.Count, cargo.maxCargo, lerpAnimationNumber);
    }

}
