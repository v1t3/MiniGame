using UnityEngine;

namespace WeaponBase
{
    public class Acorn : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 15f);
        }
    }
}