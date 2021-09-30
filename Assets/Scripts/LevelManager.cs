using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <Summary>
///  Manage the level at begining game
/// </Summary>
public class LevelManager : MonoBehaviour
{
    private int Level;
    void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            Level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level",1);
        }; 
    }
    void Start()
    {
         Invoke("LoadLevel",1f);
    }

    void LoadLevel()  // Load the level on playerprefs based
    {
         FindObjectOfType<ProgressSceneLoader>().LoadScene(Level); 
    }
}
