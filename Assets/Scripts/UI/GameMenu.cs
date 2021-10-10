using Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private TimeManager timeManager;

        [SerializeField] private GameObject menuButton;
        [SerializeField] private GameObject menuWindow;
        [SerializeField] private GameObject optionsWindow;

        private bool _isMenuOpen;
        private bool _isOptionsOpen;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isOptionsOpen)
            {
                if (!_isMenuOpen)
                {
                    OpenMenuWindow();
                }
                else
                {
                    CloseMenuWindow();
                }
            }
        }

        public void OpenMenuWindow()
        {
            _isMenuOpen = true;
            menuButton.SetActive(false);
            menuWindow.SetActive(true);
            timeManager.StopTime();
        }

        public void CloseMenuWindow()
        {
            _isMenuOpen = false;
            menuButton.SetActive(true);
            menuWindow.SetActive(false);
            timeManager.StartTime();
        }

        public void OpenOptions()
        {
            _isOptionsOpen = true;
            menuWindow.SetActive(false);
            optionsWindow.SetActive(true);
        }

        public void CloseOptions()
        {
            _isOptionsOpen = false;
            menuWindow.SetActive(true);
            optionsWindow.SetActive(false);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}