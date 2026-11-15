using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject settingsVisible;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuVisible;

    [Header("settings")]
    [SerializeField] private Slider sliderSettings;
    [SerializeField] private Slider sliderVisible;

    public void StartGameButton()
    {
        SceneManager.LoadScene("Official");
    }
    public void SettingsButton()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        menuVisible.SetActive(false);
        settingsVisible.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        menuVisible.SetActive(true);
        settingsVisible.SetActive(false);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        sliderVisible.value = sliderSettings.value;
    }

}
