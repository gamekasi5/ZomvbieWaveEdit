using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePoint : MonoBehaviour
{
    public static int BloodLife;

    public Text txtBloodLife;
    void Start()
    {
        BloodLife = 3;
    }


    void Update()
    {       
        txtBloodLife.text = BloodLife.ToString();

        if (GenarateNPC.currentenemy <= 0)
        {
            Victory();
        }

        else
        {
            die();
        }
    }

    void Victory()
    {
          SceneManager.LoadScene("Victory");
    }

    void die()
    {
        if(BloodLife <= 0)
        {
           SceneManager.LoadScene("GameOver");
        }
    }
}
