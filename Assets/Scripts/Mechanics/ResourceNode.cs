using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum ResourceStates
{
    FULL,
    DEPLETED
}

public class ResourceNode : MonoBehaviour
{

    public ResourceType resourceType;
    public ResourceStates currentResourceState;
    public GameObject resourceModule;
    public Transform resourceTransform;
    public Transform mesh;
    public Collider obj_collider;
    public float currentHealth;
    public float maxHealth;
    public float animDuration;
    public int numberOfAdded = 1;

    public float durabilityLoss = 30;

    private Vector3 originalMeshvalues;

    private void Start()
    {
        InitResource();
    }

    public void InitResource()
    {
        currentResourceState = ResourceStates.FULL;
        originalMeshvalues = mesh.transform.localScale;
        obj_collider.enabled = true;
    }

    public void LoseDurability()
    {
        if(currentHealth > 0)
        {
            currentHealth -= durabilityLoss;
            var finalFillAmount = currentHealth / 100;
            Vector3 newVector = new Vector3(finalFillAmount, finalFillAmount, finalFillAmount);

            InstantiateResourceModule();

            Cargo cargo = FindObjectOfType<Cargo>();
            cargo.AddCargo(resourceType, numberOfAdded);

            mesh.DOScale(newVector, animDuration);
        }
        else
        {
            HideNode();
        }
    }

    public void HideNode()
    {
        mesh.gameObject.SetActive(false);
        mesh.transform.localScale = originalMeshvalues;
        obj_collider.enabled = false;

    }

    public void InstantiateResourceModule()
    {
        var module = Instantiate(resourceModule);
    }
}
