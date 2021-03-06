using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class WelcomeMenu : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;
        
        public void StartGame()
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