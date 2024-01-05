using System.Collections.Generic;
using UnityEngine;


namespace TD.Core
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject Tower;
        private bool onLeft = true;
        private float posX = -1.85f;
        private List<float> leftVerticle;
        private List<float> rightVerticle;
        private Vector2 towerPosition;
        private Quaternion towerOrientation;
        void Awake()
        {
            towerOrientation.Set(0, 0, 0, 0);
            leftVerticle = new List<float>();
            rightVerticle = new List<float>();

            // Within this for loop, vertical positions are calculated for placing towers
            for (float i = -4.5f; i <= 4.5; i += 0.9f)
            {
                leftVerticle.Add(i);
                rightVerticle.Add(i);
            }
        }

        public void spawnTower()
        {
            // Puts a tower to a random spot on the left verticle positions
            if (onLeft)
            {
                if (leftVerticle.Count > 0)
                {
                    int index = Random.Range(0, leftVerticle.Count - 1);
                    towerPosition.Set(posX, leftVerticle[index]);
                    leftVerticle.RemoveAt(index);
                    posX *= -1;
                    onLeft = false;
                }
                else
                {
                    Debug.LogWarning("No More Space Left to Spawn Tower");
                    return;
                }

            }
            // Puts a tower to a random spot on the right verticle positions
            else
            {
                int index = Random.Range(0, rightVerticle.Count - 1);
                towerPosition.Set(posX, rightVerticle[index]);
                rightVerticle.RemoveAt(index);
                posX *= -1;
                onLeft = true;
            }
            GameObject spawnedTower = Instantiate(Tower, towerPosition, towerOrientation);

            if (onLeft) spawnedTower.transform.Rotate(0, 180, 0); // Rotates the towers on the right side towards the center
        }
    }
}





