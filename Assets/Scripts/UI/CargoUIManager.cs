using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CargoUIManager : MonoBehaviour
{

    private CargoManager cargoManager;
    public Image fillImage;

    private float currentImageFillAmount;
    public float lerpAnimationNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentImageFillAmount = fillImage.fillAmount;
        cargoManager = GameManager.Instance().CargoManager();

        CargoManager.AddItemsToCargo += UpdateAddFillUi;
        CargoManager.AddItemsToDeposit += UpdateReduceFillUi;
    }

    private void UpdateAddFillUi()
    {
        UIHelper.LerpAddFillImage(fillImage, cargoManager.previouslyAddedAmount, cargoManager.maxCargo, lerpAnimationNumber);
    }

    private void UpdateReduceFillUi()
    {
        UIHelper.LerpReduceFillImage(fillImage, cargoManager.SubCargoData.Resources.Values.Sum(), cargoManager.maxCargo, lerpAnimationNumber);
    }

}
