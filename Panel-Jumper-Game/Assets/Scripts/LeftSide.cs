﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSide : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Collision");
            collision.gameObject.transform.position = new Vector2(3.2f, collision.gameObject.transform.position.y);
        }
    }
}
