using UnityEngine;
using UnityEngine.UI;

namespace WeaponBase
{
    public class MachineGun : Gun
    {
        [Space(5)]
        [Header("Magazine")]
        public int numberOfBullets;
        public Text bulletsText;

        public PlayerArmory playerArmory;

        public override void Shot()
        {
            base.Shot();
            numberOfBullets--;
            UpdateText();
            
            if (numberOfBullets <= 0)
            {
                playerArmory.TakeGunByIndex(0);
            }
        }

        public override void Activate()
        {
            base.Activate();
            bulletsText.enabled = true;
            UpdateText();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            bulletsText.enabled = false;
        }

        public override void AddBullets(int bulletsCount)
        {
            base.AddBullets(bulletsCount);
            numberOfBullets += bulletsCount;
            UpdateText();
        }

        private void UpdateText()
        {
            bulletsText.text = numberOfBullets.ToString();
        }
    }
}