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

    [HideInInspector]
    public RaycastHit raycastHit;
    [HideInInspector]
    public Ray ray;

    public string lastLayerhit;

    public float ResourceDamageDuration = 1f;
    public float BaseResourceDamageAmount = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _indicatorObject = Instantiate(_pointIndicator);
        _mainCamera = Camera.main;
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
                    _indicatorObject.transform.position = raycastHit.point;
                    break;
                case "Resource":

                    HealthBarBehaviour health = hitObject.GetComponentInChildren<HealthBarBehaviour>();

                    StartCoroutine(
                        health.LoseHealth(ResourceDamageDuration, BaseResourceDamageAmount)
                        );

                    break;
            }

            lastLayerhit = LayerMask.LayerToName(hitObject.layer);
        }
    }
}
