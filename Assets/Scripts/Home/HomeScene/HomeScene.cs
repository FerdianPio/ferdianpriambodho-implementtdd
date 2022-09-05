using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPicture.HomeScene
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button playButton, themeButton;

        void Start()
        {
            playButton.onClick.RemoveAllListeners();
            themeButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(LoadGame);
            themeButton.onClick.AddListener(LoadTheme);

        }

        void LoadGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        void LoadTheme()
        {
            SceneManager.LoadScene("Theme");
        }
    }

}
