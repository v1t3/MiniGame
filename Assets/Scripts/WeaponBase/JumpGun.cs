using System;
using UI;
using UnityEngine;

namespace WeaponBase
{
    public class JumpGun : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private float speed;
        [SerializeField] private Transform spawn;
        [SerializeField] private Gun pistol;

        [SerializeField] private ChargeIcon chargeIcon;

        public float maxCharge;

        private float _currentCharge;
        private bool _isCharged;

        private void Update()
        {
            if (_currentCharge < maxCharge)
            {
                _currentCharge += Time.deltaTime;
                _isCharged = false;
                chargeIcon.SetChargeValue(_currentCharge, maxCharge);
            }
            else
            {
                _isCharged = true;
                chargeIcon.StopCharge();
            }

            if (_isCharged && Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            pistol.Shot();
            playerRb.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
            _currentCharge = 0;
            _isCharged = false;
            chargeIcon.StartCharge();
        }
    }
}