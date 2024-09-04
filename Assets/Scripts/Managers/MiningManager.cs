using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{

    public float DurabilityLoss = 30;
    public float MiningTickInterval;
    public float Timer = 0.0f;

    public bool CanBeMined;
    public bool Ticking;

    public Transform PlayerTransform;
    public SubMover SubMover;
    public Transform TargetNodeTransorm;
    public ResourceNode ResourceNode;

    public float physicsSphereOverlapRadius = 10;
    public LayerMask resourceNodeLayer;

    // Start is called before the first frame update
    void Start()
    {
        CanBeMined = true;
        Ticking = true;
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

        if (Ticking)
        {

            Timer += Time.deltaTime;

            if (Timer > MiningTickInterval)
            {
                Ticking = false;
                CanBeMined = true;
            }

        }

    }

    public void Reset()
    {
        Ticking = true;
        CanBeMined = false;
        Timer = 0;
    }

    public void Mine()
    {

        SubStateManager.ChangePlayerState(GameConstants.PlayerStates.MINNING);

        if (ResourceNode.currentHealth > 0)
        {
            ResourceNode.LoseDurability();
        }
        else
        {
            ResourceNode = null;
            TargetNodeTransorm = null;
        }

        Reset();
    }

    void FindClosestMinableNode()
    {

        Collider[] hitColliders = Physics.OverlapSphere(PlayerTransform.position, physicsSphereOverlapRadius, resourceNodeLayer);
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
                    ResourceNode = node.resourceNode;
                    TargetNodeTransorm = node.resourceTransform;
                }

            }
        }
    }

    bool CanMine()
    {
        return CanBeMined
            && ResourceNode != null
            && Vector3.Distance(TargetNodeTransorm.position, SubMover.subTransform.position) < SubMover.resourceStopDistance
             && Input.GetKeyDown(KeyCode.E);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, physicsSphereOverlapRadius);
    }

}
