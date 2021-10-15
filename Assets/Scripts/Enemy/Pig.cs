using System;
using UnityEngine;

namespace Enemy
{
    public class Pig : MonoBehaviour
    {
        [SerializeField] private Lifter lifter;

        private void Update()
        {
            lifter.GetUp();
        }
    }
}