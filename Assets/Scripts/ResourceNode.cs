using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceStates
{
    FULL,
    DEPLETED
}

public class ResourceNode : MonoBehaviour
{

    public ResourceType resourceType;
    public ResourceStates currentResourceState;
    public Transform resourceTransform;
    public Transform mesh;
    public Collider collider;
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
        collider.enabled = true;
    }


    public IEnumerator LoseDurability()
    {
        if(currentHealth > 0)
        {

            float elapsedTime = 0f;

            currentHealth -= durabilityLoss;

            var finalFillAmount = currentHealth / 100;

            Vector3 newVector = new Vector3(finalFillAmount, finalFillAmount, finalFillAmount);

            while (animDuration >= elapsedTime)
            {
                mesh.localScale = Vector3.Lerp(mesh.localScale, newVector, elapsedTime / animDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Cargo cargo = FindObjectOfType<Cargo>();

            cargo.AddCargo(resourceType, numberOfAdded);

            mesh.localScale = newVector;
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
        collider.enabled = false;

    }
}
