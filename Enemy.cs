using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    public float movespeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
    }
    void FixedUpdate()
    {
        CheckPlayyerPos();
        moveCharacter(movement);
    }

    private void CheckPlayyerPos()
    {
        Vector3 direction = player.transform.position - transform.position; // move to player
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angel;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet") 
        {
            UiData.ScorePoint += 10;
            Destroy(this.gameObject, 0.1f);
            GenarateNPC.currentenemy--;

        }

        if (other.gameObject.tag == "Player")
        {
            LifePoint.BloodLife -= 1;
            UiData.ScorePoint -= 10;
            Destroy(this.gameObject);
        }
    }
}

