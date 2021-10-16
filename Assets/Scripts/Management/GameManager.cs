using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string gameOverScene;
        [SerializeField] private string levelPassedScene;
        
        public void GameOver()
        {
            LoadScene(gameOverScene);
        }

        public void LevelPassed()
        {
            LoadScene(levelPassedScene);
        }

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
