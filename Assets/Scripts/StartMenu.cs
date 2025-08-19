using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;

    GameObject hubPanel;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }
    private void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }

    public void StartupMenu()
    {
        hubPanel.SetActive(true);
    }

   public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}