using UnityEngine;
using UnityEngine.Events;

namespace TD.Core
{
    public static class EventManager
    {

        public static event UnityAction<string> OnKill;
        public static event UnityAction OnTowerSpawn;
        public static event UnityAction OnGameOver;
        public static event UnityAction<int> OnLevelComplete;
        public static event UnityAction OnPowerUpUse;

        public static void RaiseOnKill(string type) // Events Raised when enemies are killed
        {
            OnKill?.Invoke(type);
        }

        public static void RaiseOnTowerSpawn()
        {
            OnTowerSpawn?.Invoke();
        }

        public static void RaiseOnGameOVer()
        {
            OnGameOver?.Invoke();
        }

        public static void RaiseOnLevelComplete(int level)
        {
            OnLevelComplete?.Invoke(level);
        }

        public static void RaiseOnPowerUpUse()
        {
            OnPowerUpUse?.Invoke();
        }

    }
}

