using System;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class Block : MonoBehaviour
    {
        public const string MainCamera = "MainCamera";
        
        private void Update()
        {
            Move();
        }

        /// <summary>
        /// Nesneyi her frame'de sola doğru hareket ettirir.
        /// Hareket hızı, ayarlarda tanımlı olan yatay hız değerine göre hesaplanır.
        /// </summary>
        private void Move()
        {
            transform.position += Vector3.left * (Time.deltaTime * SettingsManager.Singleton.Settings.horizontalSpeed);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(MainCamera))
            {
                Destroy(gameObject);
            }
        }
    }
}