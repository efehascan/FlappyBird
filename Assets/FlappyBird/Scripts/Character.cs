using System;
using System.Collections;
using System.Collections.Generic;
using FlappyBird.Scripts;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    #region Singleton
    public static Character Singleton { get; private set; }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        if(Singleton != null)
            Destroy(gameObject);
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    
    public const string Blocks = "Blocks";
    public const string Column = "Column";
    
    [SerializeField] TextMeshProUGUI pointsText;
    Rigidbody2D rb2d;
    /// <summary>
    /// Karakterin topladığı toplam puanı tutar.
    /// </summary>
    public int points;
    /// <summary>
    /// Karakterin ölüp ölmediğini belirten durum.
    /// </summary>
    public bool birdIsDead;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiğinde TextMeshPro referansını yeniden al
        pointsText = GameObject.Find("PointsText")?.GetComponent<TextMeshProUGUI>();
        transform.position = new Vector3(-4.5f, 0f, 0f);
    }

    private void Update()
    {
        VerticalMovement();
        UpdatePoints();
    }

    
    /// <summary>
    /// Karakterin yukarı yönlü hareketini ve dönüş açısını kontrol eder. 
    /// Space tuşuna basıldığında yukarı doğru hız uygulanır ve hareket yönüne göre karakter döndürülür.
    /// </summary>
    private void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * SettingsManager.Singleton.Settings.verticalSpeed;
        }
        
        transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * SettingsManager.Singleton.Settings.rotationSpeed);
    }

    
    /// <summary>
    /// Mevcut puanı kullanıcı arayüzündeki metin alanına yansıtarak skor bilgisini günceller.
    /// </summary>
    private void UpdatePoints()
    {
        if (pointsText != null)
            pointsText.text = "Score: " + points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Column))
        {
            points++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Blocks))
        {
            birdIsDead = true;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
