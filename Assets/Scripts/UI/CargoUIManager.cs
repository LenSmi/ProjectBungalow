using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CargoUIManager : MonoBehaviour
{

    private CargoManager cargo;
    public Image fillImage;

    private float currentImageFillAmount;
    public float lerpAnimationNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentImageFillAmount = fillImage.fillAmount;
        cargo = GameManager.Instance().Cargo();

        CargoManager.AddItemsToCargo += UpdateAddFillUi;
        CargoManager.AddItemsToDeposit += UpdateReduceFillUi;
    }

    private void UpdateAddFillUi()
    {
        UIHelper.LerpAddFillImage(fillImage, cargo.previouslyAddedAmount, cargo.maxCargo, lerpAnimationNumber);
    }

    private void UpdateReduceFillUi()
    {
        UIHelper.LerpReduceFillImage(fillImage, cargo.SubCargoInventory.Values.Sum(), cargo.maxCargo, lerpAnimationNumber);
    }

}
