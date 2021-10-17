using System;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponBase
{
    public class PlayerArmory : MonoBehaviour
    {
        [SerializeField] private Gun[] guns;

        [SerializeField] private KeyCode[] keyCodes;

        private int _currentGunIndex;

        [Space(10)] [SerializeField] private UnityEvent onGunChange;
        [SerializeField] private UnityEvent onBulletsTake;

        private void Start()
        {
            TakeGunByIndex(_currentGunIndex);
        }

        private void Update()
        {
            for (int i = 0, len = keyCodes.Length; i < len; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    TakeGunByIndex(i);
                }
            }
            
            // Переключение колёсиком
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && _currentGunIndex < guns.Length - 1)
            {
                TakeGunByIndex(_currentGunIndex + 1);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && _currentGunIndex > 0)
            {
                TakeGunByIndex(_currentGunIndex - 1);
            }
        }

        public void TakeGunByIndex(int index)
        {
            _currentGunIndex = index;

            for (int i = 0; i < guns.Length; i++)
            {
                if (guns[i] != null)
                {
                    if (i == index)
                    {
                        guns[i].Activate();
                    }
                    else
                    {
                        guns[i].Deactivate();
                    }
                }
            }

            onGunChange.Invoke();
        }

        public void AddBullets(int gunIndex, int bulletsCount)
        {
            if (guns[gunIndex] != null)
            {
                guns[gunIndex].AddBullets(bulletsCount);
                onBulletsTake.Invoke();
            }
        }
    }
}