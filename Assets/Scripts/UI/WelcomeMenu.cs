using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class WelcomeMenu : MonoBehaviour
    {
        public int sceneId;
        
        public void StartGame()
        {
            SceneManager.LoadScene(sceneId);
        }

        public void Exit()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}