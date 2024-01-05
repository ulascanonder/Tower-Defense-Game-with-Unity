using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD.Tower
{
    public class Bullet : MonoBehaviour
    {

        private float velocity = 10f;
        private Rigidbody2D body;
        [NonSerialized] public int damage;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            body.velocity = transform.right * velocity; // This line shoots bullets forward when they are spawned
        }

    }
}


