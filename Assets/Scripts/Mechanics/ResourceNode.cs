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
    public float launchSpeed;
    public float launchHeight;

    public float durabilityLoss = 30;

    private Vector3 originalMeshvalues;
    public float radius;

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
        if (currentHealth > 0)
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
        Vector3 newPosition = RandomPostionCircle(transform,radius);
        var module = Instantiate(resourceModule,transform.position,Quaternion.identity);
        Launch(module.transform, newPosition);
    }


    public Vector3 RandomPostionCircle(Transform objectTransform, float radius)
    {
        Vector3 position;

        float angle = UnityEngine.Random.Range(0, Mathf.PI *2);
        
        float angleRadian = Mathf.Rad2Deg * angle;

        //position.x = objectTransform.position.x + radius * Mathf.Sin(angleRadian);
        //position.z = objectTransform.position.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        var posX = Mathf.Cos(angleRadian);
        var posZ = Mathf.Sin(angleRadian);
        position.x = objectTransform.position.x + posX * radius;
        position.z = objectTransform.position.z + posZ * radius;
        position.y = objectTransform.position.y;

        return position;
    }
    
    public void Launch(Transform objectToLaunch, Vector3 endPoint)
    {
        DOTween.Init();
        Sequence sequence = DOTween.Sequence();

        sequence.Append(objectToLaunch.DOMove(endPoint, launchSpeed, false).SetEase(Ease.InQuad));
        sequence.Join(objectToLaunch.DOMoveY(transform.position.y + launchHeight, launchSpeed, false).SetEase(Ease.OutQuad));
        sequence.Append(objectToLaunch.DOMoveY(endPoint.y, launchSpeed, false).SetEase(Ease.OutQuad));

    }

}
