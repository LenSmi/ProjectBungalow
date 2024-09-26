using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RestorationNode : MonoBehaviour
{
    [Header("Restoration Values")]
    public bool IsRestored = false;
    public RestorationNodeUI RestorationNodeUI;
    public CargoData CargoData;

    [Header("Meshes")]
    public MeshRenderer MeshRenderer;
    public GameObject UnrestoredMesh;
    public GameObject RestoredMesh;
    public Image RestorationIcon;

    [Header("Requirements List"), 
        Tooltip("Set requirements by adding options to the array. The relevant ScriptableObject needs to be assigned based on the given type")]
    public List<RestorationRequirement> requiredResources = new List<RestorationRequirement>();
    private bool _IsColliding = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _IsColliding)
        {
            if (CheckRequirements())
            {
                Restore();
            }
            else
            {
                RequirementsNotMet();
            }
        }

    }

    public bool CheckRequirements() 
    {
        foreach (var requirement in requiredResources)
        {
            if (CargoData.GetResourceAmount(requirement.Type) < requirement.quantity)
            {
                return false;
            }
        }
        return true;
    }

    public void SetUIRequirements()
    {
        foreach (var requirement in requiredResources)
        {
            if (CargoData.GetResourceAmount(requirement.Type) > requirement.quantity)
            {
                requirement.IsMet = true;
            }
            else
            {
                requirement.IsMet = false;
            }
        }

        RestorationNodeUI.UpdateRequirements();
        RestorationNodeUI.NodeParent.SetActive(true);
    }

    private void Restore() 
    {
        RestorationNodeUI.NodeParent.SetActive(false);
        IsRestored = true;
        RestoredMesh.SetActive(true);
        UnrestoredMesh.SetActive(false);
    }

    private void RequirementsNotMet() 
    { 

        Debug.Log("Requirements not met");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.PlayerTag && !IsRestored)
        {
            _IsColliding = true;

            Color color = RestorationIcon.color;
            color.a = 0;
            RestorationIcon.DOColor(color, 0.3f);

            SetUIRequirements();
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == GameConstants.PlayerTag && !IsRestored)
        {
            _IsColliding = false;

            Color color = RestorationIcon.color;
            color.a = 1;
            RestorationIcon.DOColor(color, 0.3f);

            RestorationNodeUI.NodeParent.SetActive(false);
        }
    }

}
