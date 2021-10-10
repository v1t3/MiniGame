using UnityEngine;

namespace Weapons
{
    public class Acorn : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 15f);
        }
    }
}