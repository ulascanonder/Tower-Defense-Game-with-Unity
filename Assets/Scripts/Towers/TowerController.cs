using System.Collections.Generic;
using UnityEngine;

namespace TD.Tower
{

    public class TowerController : MonoBehaviour
    {
        //private CircleCollider2D collider;
        private Rigidbody2D body;
        public float angularSpeed = 10f;
        private Vector2 EnemyDirection;
        private bool locked = false;
        public Rifle rifle;
        private GameObject target;
        private Queue<GameObject> Targets;
        public int towerDamage;

        void Awake()
        {
            Targets = new Queue<GameObject>();
            body = GetComponent<Rigidbody2D>();
            towerDamage = Random.Range(5, 25); // Damage output is random between 10-50 Damage/Second
            rifle = GetComponentInChildren<Rifle>();
        }

        void Update()
        {
            // Attack Enemey when locked
            if (locked) Attack();
        }

        //Rotate Tower towards specified direction
        private void Rotate(Vector2 Direction)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.LookRotation(Direction);
            // Using Linear Interpolation for a smooth rotation
            body.SetRotation(Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * angularSpeed));
        }

        //Picks a target from the queue, rotates Tower towards the target and shoots
        private void Attack()
        {
            target = Targets.Peek();
            if (target == null)
            {
                Targets.Dequeue();
                return;
            }
            Vector2 targetDirection = transform.position - target.transform.position;
            Rotate(targetDirection);
            rifle.Shoot();
        }


        //When an enemy enters in to collider it is enqueued
        private void OnTriggerEnter2D(Collider2D obj)
        {
            if (!obj.CompareTag("Enemy")) return; // Only Objects with Enemy tag are enqueud
            Targets.Enqueue(obj.gameObject);
            if (!locked) locked = true;
        }

        // Lost targets are dequeud
        private void OnTriggerExit2D(Collider2D obj)
        {
            if (!obj.CompareTag("Enemy")) return;
            Targets.Dequeue();
            if (Targets.Count == 0) locked = false;
        }

    }
}


