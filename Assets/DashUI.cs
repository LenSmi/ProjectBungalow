using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    private SubMover subMover;
    public Image fillImage;
    public float lerpAnimationNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        subMover = FindObjectOfType<SubMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!subMover.Overheated)
        {
            fillImage.fillAmount = subMover.HeatLevel / 100;
        }
        else
        {
            fillImage.fillAmount = subMover.HeatLevel / 100;
        }
    }

    IEnumerator Overload()   
    {
        yield return null;
    }
}
