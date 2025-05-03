using System;
using System.Collections;
using UnityEngine;

namespace FlappyBird.Scripts
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] GameObject blockPrefab;
        [SerializeField] private Character character;
        
        Coroutine _spawnCoroutine;
        readonly WaitForSeconds wait = new WaitForSeconds(1.5f);
        
        Vector3 spawnPos = new Vector3(14f, 0f, 0f);


        private void Start()
        {
            _spawnCoroutine = StartCoroutine(Spawner());
        }

        
        /// <summary>
        /// Belirtilen yükseklik aralığında rastgele bir Y pozisyonu belirleyerek yeni bir blok nesnesi oluşturur.
        /// </summary>
        private void SpawnBlock()
        {
            spawnPos.y = UnityEngine.Random.Range(-SettingsManager.Singleton.Settings.height, SettingsManager.Singleton.Settings.height);
            Instantiate(blockPrefab, spawnPos, Quaternion.identity);
        }


        
        /// <summary>
        /// Karakter hayatta olduğu sürece belirli aralıklarla blok üretimini sağlayan coroutine fonksiyonudur.
        /// </summary>
        IEnumerator Spawner()
        {
            while (!character.birdIsDead)
            {
                SpawnBlock();
                yield return wait;
            }
        }
        
        #region On Disable and On Destroy
    
        private void OnDisable()
        {
        
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private void OnDestroy()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        #endregion
        
    }
}