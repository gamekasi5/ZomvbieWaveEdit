using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenarateNPC : MonoBehaviour
{
    public GameObject NpcPrefab;
    public int posX;
    public int posY;
    public int enemyCount = 0;
    public int amountEnemy = 50;

    public static int currentenemy = 40;
    public Text txtEnemy;

    void Start()
    {

    }


    void Update()
    {
        while (enemyCount < amountEnemy)
        {
            posX = Random.Range(-40, 40);
            posY = Random.Range(-20, 20);

            Instantiate(NpcPrefab, new Vector3(posX, posY, 0), Quaternion.identity);

            enemyCount += 1;
        }
        TextVictory();
    }
    
    void TextVictory()
    {
        txtEnemy.text = currentenemy.ToString();
    }
}
