using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <Summary>
///  Level Text
/// </Summary>
public class LevelUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text LevelText;
    public TMP_Text LevelCompleteText;
    void Start()
    {
         LevelText.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex;
         LevelCompleteText.text = "COMPLETE"+ "\n" + "LEVEL " + SceneManager.GetActiveScene().buildIndex;
    }
}
