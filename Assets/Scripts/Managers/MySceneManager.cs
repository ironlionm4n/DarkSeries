using System;
using Helpers.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MySceneManager : Singleton<MySceneManager>
    {
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private AsyncOperation _asyncOperation;

        public void StartGame()
        {
            _asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
        }

        private void Update()
        {
            if (_asyncOperation == null) return;

            if (_asyncOperation.progress >= 0.9f)
            {
                _asyncOperation.allowSceneActivation = true;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _asyncOperation = null;
            if (scene.name == "InitScene")
            {
                MainMenuInputManager.Instance.gameObject.SetActive(false);
            }

            if (scene.name == "MainMenu")
            {
                MainMenuInputManager.Instance.gameObject.SetActive(true);
            }
        }

        public void StopGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}