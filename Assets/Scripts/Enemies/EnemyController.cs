using Unity.VisualScripting;
using UnityEngine;
using TD.Tower;
using UnityEngine.UI;
using TD.Core;
using DG.Tweening;
using System;


namespace TD.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Rigidbody2D body;
        public float speed = 0.05f;
        private Vector2 movement;
        private Slider slider;
        private GameManager gameManagerCmp;
        public bool isRed;

        [SerializeField] private int Health;
        private int maxHealth;

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            slider = GetComponentInChildren<Slider>();
            //Move Enemy with DOtween and raise game over event when it reaches its destination
            transform.DOMoveY(-5.4f, 20).SetEase(Ease.Linear).OnComplete(() => EventManager.RaiseOnGameOVer());
        }
        void Start()
        {
            gameManagerCmp = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            Health = gameManagerCmp.enemyHealth;
            if (isRed) Health = (int)Math.Round(Health * 1.1f);
            maxHealth = Health;
        }

        void Update()
        {
            body.MovePosition(body.position + movement * speed * Time.deltaTime); // Moves Down the enemy with a constant speed
            if (Health == 0) enemyDeath();
        }

        private void OnTriggerEnter2D(Collider2D obj)
        {
            // Enemy recieves damage upon colliding with a bullet
            if (!obj.CompareTag("Bullet")) return; // This method only works when enemies collide with bullets
            GameObject projectile = obj.GameObject();
            Bullet bullet = projectile.GetComponent<Bullet>();
            Health = Health > bullet.damage ? Health - bullet.damage : 0;
            slider.value = Health / (float)maxHealth;
            Destroy(projectile); // Bullet is destroyed
        }

        private void enemyDeath()
        {
            // Kills the enemy and Rasies an event to increase score
            if (isRed) EventManager.RaiseOnKill("red");
            else EventManager.RaiseOnKill("white");
            Destroy(this.GameObject());
        }

    }
}







