using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiData : MonoBehaviour
{
    public Image DesertEagel, M4A2, Beratta;

    public static int ScorePoint;
    public Text txtScorePoint;
    

    void Start()
    {
        DesertEagel.gameObject.SetActive(true);
        M4A2.gameObject.SetActive(false);
        Beratta.gameObject.SetActive(false);
    }


    void Update()
    {

        switch (Shoot.ChangWeapon)
        {
            case 0:
                DesertEagel.gameObject.SetActive(true);
                M4A2.gameObject.SetActive(false);
                Beratta.gameObject.SetActive(false);
                break;

            case 1:
                DesertEagel.gameObject.SetActive(false);
                M4A2.gameObject.SetActive(true);
                Beratta.gameObject.SetActive(false);
                break;

            case 2:
                DesertEagel.gameObject.SetActive(false);
                M4A2.gameObject.SetActive(false);
                Beratta.gameObject.SetActive(true);
                break;

        }
        TextBox();
    }
    void TextBox()
    {
        txtScorePoint.text = ScorePoint.ToString();
    }
}
    
