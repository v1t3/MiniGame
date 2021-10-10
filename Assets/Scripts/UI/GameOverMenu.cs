using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        
        public void Restart()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public void Exit()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}