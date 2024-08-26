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

    public float physicsSphereOverlapRadius = 10;
    public LayerMask resourceNodeLayer;

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

        FindClosestMinableNode();

        if (CanMine())
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

    void FindClosestMinableNode()
    {

        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, physicsSphereOverlapRadius, resourceNodeLayer);
        float previousClosestNode = Mathf.Infinity;

        foreach (Collider collider in hitColliders)
        {
            float distanceToNode = Vector3.Distance(transform.position, collider.transform.position);

            if (distanceToNode < previousClosestNode) 
            {
                previousClosestNode = distanceToNode;
                ResourceNode node = collider.GetComponent<ResourceNode>();

                if (node != null)
                {
                    resourceNode = node.resourceNode;
                    targetNodeTransorm = node.resourceTransform;
                }

            }
        }
    }

    bool CanMine()
    {
        return canMine
            && resourceNode != null
            && Vector3.Distance(targetNodeTransorm.position, mover.subTransform.position) < mover.resourceStopDistance
             && Input.GetKeyDown(KeyCode.E);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, physicsSphereOverlapRadius);
    }

}
