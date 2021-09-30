using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <Summary>
///  Guide Manager to new player
/// </Summary>
public class GuideManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> guidetxt;
    public TMP_Text guidetext;
    public List<Sprite> icons;
    public Image icon;
    private int i = 0;
    public GameObject NotifyPanel;
    void Start()
    {
        InvokeRepeating("ShowGuidePanel", 3f, 3f);
    }

    void ShowGuidePanel()   // Trigger the guide panel
    {
        if(i == 3)
        {
           NotifyPanel.SetActive(false);
           CancelInvoke("ShowGuidePanel");
        }
        guidetext.text= guidetxt[i];
        icon.sprite = icons[i];
        i++;
    }
}
