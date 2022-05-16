using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CollisionDetector : Detector
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Entity>(out Entity entity))
        {
            InvokeDetector(entity);
            return;
        }

        Debug.Log("Ошибка, обьект" + this.gameObject.name + " столкнулся не с сущностью");
    }
}
