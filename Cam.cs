using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
//chage follow player
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.y = player.position.y;
        pos.z = player.position.z - 6f;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
