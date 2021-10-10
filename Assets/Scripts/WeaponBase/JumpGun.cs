using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WeaponBase
{
    public class JumpGun : Gun
    {
        [Space(5)]
        [Header("JumpGun")]
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private float shotSpeed;
        [SerializeField] private Transform jumpSpawn;

        [SerializeField] private JumpGunRecharger recharger;

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (recharger.isCharged && Input.GetMouseButtonDown(0))
            {
                Shot();
            }
        }

        public override void Shot()
        {
            base.Shot();
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(-jumpSpawn.forward * shotSpeed, ForceMode.VelocityChange);
            recharger.Recharge();
        }
    }
}