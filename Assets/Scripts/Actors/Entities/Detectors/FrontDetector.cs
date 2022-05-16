using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class FrontDetector : Detector
{

    private float _detectionDistance;
    private bool _isDetection = true;
    
    private void OnEnable() => UpdateService.OnUpdate += Detect;

    public void SetDetectionDistance(float range) => _detectionDistance = range;
    private void Detect()
    {
        Entity entity;
        
        if (IsTargetInRadius(out entity) && _isDetection)
        {
            InvokeDetector(entity);
            _isDetection = false;
        }

        if (IsTargetInRadius(out entity) == false && _isDetection == false)
            _isDetection = true;
    }
    
    private bool IsTargetInRadius(out Entity entit)
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction * _detectionDistance, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent<Entity>(out Entity entity))
            {
                entit = entity;
                return true;
            }    
        }
        

        entit = null;
        return false;
    }

    private void OnDisable() => UpdateService.OnUpdate -= Detect;
}
