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
