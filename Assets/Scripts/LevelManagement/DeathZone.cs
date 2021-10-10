using PlayerBase;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerMove>())
            {
                LoadScene(sceneName);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
