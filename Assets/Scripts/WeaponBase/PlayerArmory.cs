using System;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponBase
{
    public class PlayerArmory : MonoBehaviour
    {
        public enum Armory
        {
            Knife = 0,
            Pistol = 1,
            MachineGun = 2,
            JumpGun = 3,
            MassGun = 4
        }

        [SerializeField] private Gun[] guns;

        public Armory currentGun;
        private int _currentGunIndex;

        [Space(10)] [SerializeField] private UnityEvent onGunChange;
        [SerializeField] private UnityEvent onBulletsTake;

        private void Start()
        {
            TakeGunByIndex(currentGun.GetHashCode());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TakeGunByIndex(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TakeGunByIndex(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TakeGunByIndex(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                TakeGunByIndex(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                TakeGunByIndex(4);
            }
            
            // Переключение колёсиком
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && _currentGunIndex < Enum.GetValues(typeof(Armory)).Length - 1)
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
            // Обновить поле текущего оружия
            foreach (Armory armory in Enum.GetValues(typeof(Armory)))
            {
                if (armory.GetHashCode() == index)
                {
                    _currentGunIndex = index;
                    currentGun = armory;
                    break;
                }
            }

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