using UnityEngine;

namespace WeaponBase
{
    public class PlayerArmory : MonoBehaviour
    {
        [SerializeField] private Gun[] guns;

        public int currentGunIndex;

        private void Start()
        {
            TakeGunByIndex(currentGunIndex);
        }

        public void TakeGunByIndex(int index)
        {
            currentGunIndex = index;

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
