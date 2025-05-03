using UnityEngine;

namespace FlappyBird.Scripts
{
    [CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 1)]
    public class Settings : ScriptableObject
    {
        [Header("Bird Settings")]
        public float verticalSpeed;
        public float rotationSpeed;
        
        [Header("Block Settings")]
        public float horizontalSpeed;

        [Header("Block Spawn Settings")] 
        public float height;


    }
}