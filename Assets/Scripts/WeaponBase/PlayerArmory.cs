using System;
using UnityEngine;

namespace WeaponBase
{
    public class PlayerArmory : MonoBehaviour
    {
        public enum Armory
        {
            Pistol = 0,
            MachineGun = 1,
            JumpGun = 2
        }
        
        [SerializeField] private Gun[] guns;

        public Armory currentGun;

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
        }

        public void TakeGunByIndex(int index)
        {
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

        public void AddBullets(int gunIndex, int bulletsCount)
        {
            guns[gunIndex].AddBullets(bulletsCount);
        }
    }
}
