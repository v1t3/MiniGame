using UI;
using UnityEngine;

namespace WeaponBase
{
    public class JumpGunRecharger : MonoBehaviour
    {
        [SerializeField] private ChargeIcon chargeIcon;

        [SerializeField] private float maxCharge = 3;
        [SerializeField] private float chargeSpeed = 1;

        public bool isCharged;
        private float _currentCharge;

        private void Start()
        {
            _currentCharge = maxCharge;
        }

        private void Update()
        {
            if (_currentCharge < maxCharge)
            {
                _currentCharge += Time.unscaledDeltaTime * chargeSpeed;
                isCharged = false;
                chargeIcon.SetChargeValue(_currentCharge, maxCharge);
            }
            else
            {
                isCharged = true;
                chargeIcon.StopCharge();
            }
        }

        public void Recharge()
        {
            _currentCharge = 0;
            isCharged = false;
            chargeIcon.StartCharge();
        }
    }
}