using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RepeatGame : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject repeatButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject sensetivity;
    [SerializeField] private GameObject soundEffects;
    [SerializeField] private GameObject soundMusic;

    private bool vol=true;
    private bool paused = false;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!winText.activeSelf)
        {
            if (!paused)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
                paused = true;
                panelPause.SetActive(true);
                
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                paused = false;
                panelPause.SetActive(false);
               

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetScoreAndHealth();
            Escp();
        }
    }
    public void Escp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void OnEnable()
    {
        EventManager.eventOnHealthUpdate += CheckHealth;
        EventManager.eventOnWinGame += WinText;
    }
    void OnDisable()
    {
        EventManager.eventOnHealthUpdate -= CheckHealth;
        EventManager.eventOnWinGame -= WinText;
    }
    public void CheckHealth()
    {
        if (ScharedData.Health<=0)
        {
            LosetextAnable();
            Time.timeScale = 0;
            ResetScoreAndHealth();
        }
        
    }
    private void LosetextAnable()
    {
        loseText.SetActive(true);
        repeatButton.SetActive(true);
        exitButton.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("_1Scene");
        Time.timeScale = 1;
    }
    private void ResetScoreAndHealth()
    {
        ScharedData.Health = 3;
        ScharedData.Score = 0;
        EventManager.eventOnScoreUpdate();
    }
    private void WinText()
    {
        ResetScoreAndHealth();
        Time.timeScale = 0;
        winText.SetActive(true);
        exitButton.SetActive(true);
        repeatButton.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void VolumeChangeEffects()
    {
        ScharedData.VolumeEffects= soundEffects.GetComponent<Slider>().value;
        EventManager.eventOnSoundChange();
       
    }
    public void VolumeChangeMusic()
    {
        ScharedData.VolumeMusic = soundMusic.GetComponent<Slider>().value;
        EventManager.eventOnSoundChange();

    }
    public void SensetivityChange()
    {
        ScharedData.Sensitivity = sensetivity.GetComponent<Slider>().value;
    }
}
