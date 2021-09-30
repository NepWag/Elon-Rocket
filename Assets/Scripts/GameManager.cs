using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/// <Summary>
///  Game Manager: manages all the system
/// </Summary>
public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public AudioSource Background;
    public Slider slider;
    private int Point;
    public TMP_Text GameOverGemPoint;
    public static GameManager instance;
    public GameObject GameOverPanel;
    public Animator NoGemAnim;
    public AudioSource GameOverSound;
    public List<Button> ControlButton;
    private int level;
    private void Awake()
    {
           if(instance == null)
           {
                instance = this;
           }
           Point=PlayerPrefs.GetInt("Point");
           level = SceneManager.GetActiveScene().buildIndex;
           PlayerPrefs.SetInt("Level",level);
           FindObjectOfType<ProgressSceneLoader>().LoadScene(level); 
    }
    public void RestartGame()
    {
           Time.timeScale = 1;
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
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
         if(Point >= 1)
         {
                Point -= 1;
                PlayerPrefs.SetInt("Point",Point);
                SkipGame();
         }
         else if(Point < 1)
         {
                NoGemAnimFunc();
         }
    }

    public void SkipGame()
    {
           FindObjectOfType<ProgressSceneLoader>().LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
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
           Invoke("GameOverPanelTrigger",2f);
           SetPoint();
           DisableButton();
    }
    public void GameOverPanelTrigger()
    {
           Player.SetActive(false);
           GameOverSound.Play();
           Invoke("MuteMusic", 0.5f);
           GameOverPanel.SetActive(true);
    }
    public void MuteMusic()
    {
         GameOverSound.mute = true;
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
                cbtn.gameObject.SetActive(false);
         }
    }
}
