using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.WSA;
using System;

public enum ResourceStates
{
    FULL,
    DEPLETED
}

public class ResourceNode : MonoBehaviour
{
    [Header("References")]
    public ResourceType resourceType;
    public ResourceStates currentResourceState;
    public GameObject resourceModule;
    public Transform resourceTransform;
    public Transform mesh;
    public Collider obj_collider;

    [Header("Durability")]
    public float maxHealth;
    private float currentHealth;
    public float animDuration;
    public float durabilityLoss = 30;

    [Header("Launch settings")]
    public float launchSpeed;
    public float launchHeight;
    public float radius;
    public float launchEndPointExtra;

    private Vector3 originalMeshvalues;
    private Transform playerTransform;


    private void Start()
    {
        InitResource();
    }

    public void InitResource()
    {
        currentResourceState = ResourceStates.FULL;
        originalMeshvalues = mesh.transform.localScale;
        obj_collider.enabled = true;
        currentHealth = maxHealth;
    }

    public void LoseDurability()
    {
        if (currentHealth > 0)
        {
            currentHealth -= durabilityLoss;
            var finalFillAmount = currentHealth / 100;
            Vector3 newVector = new Vector3(finalFillAmount, finalFillAmount, finalFillAmount);

            InstantiateResourceModule();

            mesh.DOScale(newVector, animDuration);

        }
        else
        {
            HideNode();
        }
    }

    private void HideNode()
    {
        mesh.gameObject.SetActive(false);
        mesh.transform.localScale = originalMeshvalues;
        obj_collider.enabled = false;

    }

    public void InstantiateResourceModule()
    {
        Vector3 newPosition = FindPlayerSubPosition();
        var module = Instantiate(resourceModule,transform.position,Quaternion.identity);
        Launch(module.transform, newPosition);
    }

    private Vector3 FindPlayerSubPosition()
    {
        if(playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag(GameConstants.PlayerSubTag).GetComponent<Transform>();
        }
        
        Vector3 position = playerTransform.position;
        return position;
    }
    
    private void Launch(Transform objectToLaunch, Vector3 endPoint)
    {

        Sequence sequence = DOTween.Sequence();

        sequence.Append(objectToLaunch.DOMove(endPoint, launchSpeed, false).SetEase(Ease.InQuad));
        sequence.Join(objectToLaunch.DOMoveY(transform.position.y + launchHeight, launchSpeed, false).SetEase(Ease.OutQuad));
        sequence.Append(objectToLaunch.DOMoveY(endPoint.y + launchEndPointExtra, launchSpeed, false).SetEase(Ease.OutQuad));
        
    }

}
