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

    public GameConstants.ResourceType resourceType;
    public ResourceStates currentResourceState;
    public HealthBarBehaviour healthBar;
    public Transform resourceTransform;
    public Transform mesh;
    public float currentHealth;
    public float maxHealth;
    public float animDuration;
    public int numberOfAdded = 1;

    public float durabilityLoss = 30;

    private void Start()
    {
        InitResource();
    }

    public void InitResource()
    {
        currentResourceState = ResourceStates.FULL;
    }


    public IEnumerator LoseDurability()
    {
        StartCoroutine(healthBar.LoseHealth(animDuration,durabilityLoss));

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
        yield return null;
    }

    public void HideNode()
    {

    }
}
