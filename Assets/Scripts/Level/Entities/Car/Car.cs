﻿using UnityEngine;
using Components;

namespace Entities
{
    public class Car : Entity
    {
        public CarColorChanger CarColorChanger { get; private set; }
        public float Size { get; private set; }

        private void Awake() 
        {
            CarColorChanger = GetComponent<CarColorChanger>();
            Size = GetComponentInChildren<Collider>().bounds.size.z;
        } 
    }
}