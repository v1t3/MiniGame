using Management;
using UnityEngine;

namespace PlayerBase
{
    public class PlayerLevelSuccess : MonoBehaviour
    {
        private GameManager _gameManager;
        
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerMove>())
            {
                _gameManager.LevelPassed();
            }
        }
    }
}