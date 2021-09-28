using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource Background;
    public Slider slider;
    private int Point;
    public TMP_Text GameOverGemPoint;
    public static GameManager instance;
    public GameObject GameOverPanel;
    public Animator NoGemAnim;
    public AudioSource GameOverSound;
    public List<Button> ControlButton;
    private void Awake()
    {
         if(instance == null)
         {
              instance = this;
         }
          Point=PlayerPrefs.GetInt("Point");
    }
    public void RestartGame()
    {
         SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }
    public void SkipGame()
    {
         SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex  + 1 );
    }

    public void VolumeAdjust()
    {
        Background.volume = slider.value;
    }

    public void SetPoint()
    {
         GameOverGemPoint.text = PlayerPrefs.GetInt("Point") +"";
    }

    public void OnPressSkip()
    {
         if(Point >= 10)
         {
              Point -= 10;
              PlayerPrefs.SetInt("Point",Point);
              SkipGame();
         }
         else
         {
              NoGemAnimFunc();
         }
    }
    public void NoGemAnimFunc()
    {
        NoGemAnim.enabled = true;
        Invoke("StopNoGemAnimFunc",2.5f);
    }
    public void StopNoGemAnimFunc()
    {
          NoGemAnim.enabled = false;
    }
    public void GameOver()
    {
           Invoke("GameOverPanelTrigger",1f);
           SetPoint();
           DisableButton();
    }
    public void GameOverPanelTrigger()
    {
          GamePaused();
          GameOverSound.Play();
          GameOverPanel.SetActive(true);
    }
    public void GamePaused()
    {
         Time.timeScale = 0;
    }
    public void GameResume()
    {
         Time.timeScale = 1;
    }

    public void DisableButton()
    {
         foreach (var cbtn in ControlButton)
         {
             cbtn.interactable = false;
         }
    }
}
