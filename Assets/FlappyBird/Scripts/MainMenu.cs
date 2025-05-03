using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI lastScoreText2;
    /// <summary>
    /// Son oynanan oyundan elde edilen skor.
    /// </summary>
    private int lastScore;

    private void Update()
    {
        LastScoreUpdate();
    }

    
    /// <summary>
    /// Character Singleton'dan alınan skoru UI'a yansıtır.
    /// </summary>
    private void LastScoreUpdate()
    {
        if(Character.Singleton != null)
            lastScore = Character.Singleton.points;

        
        lastScoreText.text = "Last Score: " + lastScore.ToString();
        lastScoreText2.text = "Last Score: " + lastScore.ToString();
    }


    /// <summary>
    /// Oyundan çıkış işlemini gerçekleştirir.
    /// Unity Editor içindeyse durdurur, değilse uygulamayı kapatır.
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


    /// <summary>
    /// Oyunu başlatır ve skor bilgisini sıfırlayarak sahneyi yeniden yükler.
    /// </summary>
    public void Play()
    {
        Character.Singleton.points = 0;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
