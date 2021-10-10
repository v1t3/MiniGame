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
            JumpGun = 3
        }
        
        [SerializeField] private Gun[] guns;

        public Armory currentGun;
        
        [Space(10)] 
        [SerializeField] private UnityEvent onGunChange;
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
        }

        public void TakeGunByIndex(int index)
        {
            // Обновить поле текущего оружия
            foreach (Armory armory in Enum.GetValues(typeof(Armory)))
            {
                if (armory.GetHashCode() == index)
                {
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
