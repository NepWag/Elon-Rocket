using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <Summary>
///  Score Counting based on coin touch
/// </Summary>
public class PointManager : MonoBehaviour
{
    public static PointManager  instance;
    private int Point;
    public TMP_Text PointUi;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if (PlayerPrefs.HasKey("Point"))
        {
        }
        else
        {
            PlayerPrefs.SetInt("Point",0);
        }; 
    }

    void Start()
    {
         Point=PlayerPrefs.GetInt("Point");
         PointUi.text = Point + "";
    }

    public void AddPoint()
    {
        Point++;
        PointUi.text = Point + "";
        PlayerPrefs.SetInt("Point",Point);
    }
}
