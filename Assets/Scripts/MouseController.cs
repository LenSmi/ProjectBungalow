using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]
    private GameObject _pointIndicator;
    private GameObject _indicatorObject;
    public LayerMask layerMask;
    public SubMover subMover;
    public MiningManager miningManager;

    [HideInInspector]
    public RaycastHit raycastHit;
    [HideInInspector]
    public Ray ray;

    public string lastLayerhit;

    public float ResourceDamageDuration = 1f;
    public float BaseResourceDamageAmount = 20f;

    public float resourceRadiusThreshold;
    public float indicatorRadiusThreshold;

    [HideInInspector]
    public float distanceThreshold;

    public Vector3 movementPoint;

    // Start is called before the first frame update
    void Start()
    {
        _indicatorObject = Instantiate(_pointIndicator);
        _mainCamera = Camera.main;
        subMover = FindObjectOfType<SubMover>();
        if(_mainCamera == null) { Debug.LogWarning("No Main Camera found", gameObject); }
        if(_pointIndicator == null) { Debug.LogWarning("No Point Indicator found", gameObject); }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 100f;
        mousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }
   
    public void HandleClick()
    {
        ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
        {
            GameObject hitObject = raycastHit.collider.gameObject;
            
            
            switch (LayerMask.LayerToName(hitObject.layer))
            {
                case "Ground":
                    subMover.stopDistance = subMover.indicatorStopDistance;
                    _indicatorObject.transform.position = raycastHit.point;
                    movementPoint = raycastHit.point;
                    SubStateManager.ChangePlayerState(GameConstants.PlayerStates.MOVING);

                    break;
                case "Resource":

                    ResourceNode resource = hitObject.GetComponentInChildren<ResourceNode>();
                    _indicatorObject.transform.position = resource.transform.position;
                    movementPoint = resource.transform.position;
                    subMover.stopDistance = subMover.resourceStopDistance;
                    Debug.Log(Vector3.Distance(hitObject.transform.position, subMover.subTransform.position));

                    if (Vector3.Distance(hitObject.transform.position, subMover.subTransform.position) < subMover.stopDistance && miningManager.canMine)
                    {
                        SubStateManager.ChangePlayerState(GameConstants.PlayerStates.MINNING);

                        if (miningManager.canMine)
                        {
                            StartCoroutine(resource.LoseDurability());
                            miningManager.Reset();
                        }
                        
                    }

                    break;
            }

            lastLayerhit = LayerMask.LayerToName(hitObject.layer);
        }
    }
}
