using System;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class PlayerReturner : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private void Start()
        {
            if (player != null)
            {
                player.transform.position = new Vector3(-4.5f, 0f, 0f);
            }
        }
    }
}