using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{

    public float durabilityLoss = 30;
    public float miningTickInterval;
    public float timer = 0.0f;

    public bool canMine;
    public bool ticking;

    public Transform playerTransform;
    public SubMover mover;
    public Transform targetNodeTransorm;
    public ResourceNode resourceNode;

    // Start is called before the first frame update
    void Start()
    {
        canMine = true;
        ticking = true;
    }

    // Update is called once per frame
    void Update()
    {
        MiningTick();

        Debug.Log(CanMine());

        if (CanMine() && Input.GetKeyDown(KeyCode.E))
        {
            Mine();
        }
    }

    public void MiningTick()
    {

        if (ticking)
        {

            timer += Time.deltaTime;

            if (timer > miningTickInterval)
            {
                ticking = false;
                canMine = true;
            }

        }

    }

    public void Reset()
    {
        ticking = true;
        canMine = false;
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag(GameConstants.ResourceNodeTag))
        {
            if(resourceNode == null)
            {
                resourceNode = other.GetComponent<ResourceNode>().resourceNode;
                targetNodeTransorm = resourceNode.resourceTransform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConstants.ResourceNodeTag))
        {
            Debug.Log("Exitted trigger");
            resourceNode = null;
            targetNodeTransorm = null;
        }

    }

    public void Mine()
    {

        SubStateManager.ChangePlayerState(GameConstants.PlayerStates.MINNING);

        if (resourceNode.currentHealth > 0)
        {
            resourceNode.LoseDurability();
        }
        else
        {
            resourceNode = null;
            targetNodeTransorm = null;
        }

        Reset();
    }

    bool CanMine()
    {
        return canMine
            && resourceNode != null
            && Vector3.Distance(targetNodeTransorm.position, mover.subTransform.position) < mover.resourceStopDistance;
    }
}
