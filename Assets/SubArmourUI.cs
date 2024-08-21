using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubArmourUI : MonoBehaviour
{
    private SubArmour subArmour;
    public Image fillImage;
    public float lerpAnimationNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        subArmour = FindObjectOfType<SubArmour>();
        subArmour.GainArmourAction += UpdateArmour;
        subArmour.LoseArmourAction += UpdateArmour;
    }

    // Update is called once per frame
    void UpdateArmour()
    {
        fillImage.fillAmount = subArmour.currentArmourAmount / subArmour.maxArmourAmount;
    }
}
