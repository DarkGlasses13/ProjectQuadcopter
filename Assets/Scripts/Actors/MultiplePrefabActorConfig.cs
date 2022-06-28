<<<<<<< Updated upstream
﻿using System.Collections.Generic;
using UnityEngine;
=======
﻿using System;
>>>>>>> Stashed changes

namespace Assets.Scripts
{
    public class MultiplePrefabActorConfig : Config
    {
<<<<<<< Updated upstream
        [SerializeField] protected List<A> _prefabs;

        private int _prefabIndex;

        public A Prefab
        {
            get
            {
                _prefabIndex = (_prefabIndex == _prefabs.Count) ? 0 : _prefabIndex;
                A prefab = _prefabs[_prefabIndex];
                _prefabIndex++;
                return prefab;
            }
        }

        public int PrefabsCount => _prefabs.Count;
=======
        protected A GetPrefab<A>(A[] prefabs, ref int prefabIndex) where A : Actor
        {
            if (prefabs.Length == 0)
                throw new Exception("Нет доступного префаба");

            prefabIndex = (prefabIndex == prefabs.Length) ? 0 : prefabIndex;
            A prefab = prefabs[prefabIndex];
            prefabIndex++;
            return prefab;
        }
>>>>>>> Stashed changes
    }
}
