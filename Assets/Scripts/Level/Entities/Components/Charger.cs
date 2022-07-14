﻿using UnityEngine;
using System;
using System.Collections;
using General;
using Entities;

namespace Components
{
    class Charger : ConfigReceiver<QuadcopterConfig>
    {
        public Action<int> OnChanged;
        public Action OnDecreased;
        public Action OnDischarged;

        private int _charge;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _chargeDownRoutine;

        public int Charge
        {
            get => _charge;

            private set
            {
                _charge = value;
                OnChanged?.Invoke(_charge);
            }
        }

        public void Recharge() 
        {
            Charge = _config.ChargeLimit;
            ResartChargeingDown();
        }

        public void ResartChargeingDown()
        {
            if (_chargeDownRoutine != null)
            {
                StopCoroutine(_chargeDownRoutine);
            }

            _chargeDownRoutine = StartCoroutine(ChargeDowning());
        }

        public void StopChargeingDown() => StopCoroutine(_chargeDownRoutine);

        private IEnumerator ChargeDowning()
        {
            _waitForSeconds = new(_config.ChargeDecreaseTime);

            while(Charge > 0)
            {
                yield return _waitForSeconds;
                Charge--;
                OnDecreased?.Invoke();
            }

            OnDischarged?.Invoke();
            yield break;
        }
    }
}