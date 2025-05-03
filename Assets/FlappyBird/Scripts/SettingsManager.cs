using System;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Singleton { get; private set; }

        public Settings Settings;

        private void Awake()
        {
            if(Singleton != null)
                Destroy(gameObject);
            else
            {
                Singleton = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}