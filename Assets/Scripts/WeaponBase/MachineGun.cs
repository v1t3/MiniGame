using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WeaponBase
{
    public class MachineGun : Gun
    {
        [Space(5)] [Header("MachineGun")] [SerializeField]
        private int numberOfBullets;

        [SerializeField] private Text bulletsText;

        [SerializeField] private UnityEvent onEmptyGunClip;

        public override void Shot()
        {
            if (numberOfBullets > 0)
            {
                base.Shot();
                numberOfBullets--;
                UpdateText();
            }
            else
            {
                onEmptyGunClip.Invoke();
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