using TD.Core;
using UnityEngine;

namespace TD.Tower
{
    public class Rifle : MonoBehaviour
    {
        [SerializeField] private GameObject Bullet;
        [SerializeField] private float BaseFireRate = 0.5f;
        [SerializeField] private float powerUpDuration = 4;
        private float RateOfFire;
        private AudioSource audioCmp;
        private AudioClip clipCmp;

        private float timer1; //Timer For Shooting
        private float timer2 = 0; //Timer For PowerUp
        private bool powerUpActive = false;


        public void Awake()
        {
            audioCmp = GetComponent<AudioSource>();
            RateOfFire = BaseFireRate;
            timer1 = RateOfFire;
        }

        public void Update()
        {
            // Timer helps allows spawning 2 bullets/sec
            if (timer1 > 0)
            {
                timer1 -= Time.deltaTime;
            }
            else
            {
                timer1 = RateOfFire;
            }
            // When Power up is on the fire rate will increase for 4 seconds
            if (powerUpActive)
            {
                RateOfFire = BaseFireRate / 1.5f;
                if (timer2 < powerUpDuration)
                {
                    timer2 += Time.deltaTime;
                }
                else
                {
                    powerUpActive = false;
                    RateOfFire = BaseFireRate;
                }
            }
        }


        void OnEnable()
        {
            EventManager.OnPowerUpUse += activatePowerUp;
        }
        void OnDisable()
        {
            EventManager.OnPowerUpUse -= activatePowerUp;
        }
        public void Shoot()
        {
            if (timer1 <= 0)
            {

                audioCmp.Play(); // Plays the shooting sound
                GameObject spawndeBullet = Instantiate(Bullet, transform.position, transform.rotation); // Spawns and shoots a bullet
                spawndeBullet.GetComponent<Bullet>().damage = GetComponentInParent<TowerController>().towerDamage; // Sets bullet damage
            }
        }

        private void activatePowerUp() { powerUpActive = true; }

    }
}


