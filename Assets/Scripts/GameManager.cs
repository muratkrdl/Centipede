using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject gameOver;

    Blaster blaster;
    Centipede centipede;
    MushroomField mushroomField;

    int score;
    int lives;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        if(Instance = this)
        {
            Instance = null;
        }    
    }

    void Start() 
    {
        blaster = FindObjectOfType<Blaster>();
        centipede = FindObjectOfType<Centipede>();
        mushroomField = FindObjectOfType<MushroomField>();

        NewGame();
    }

    void Update() 
    {
        if(lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }    
    }

    void NewGame()
    {
        SetScore(0);
        SetLives(3);

        centipede.Respawn();
        blaster.Respawn();
        mushroomField.Clear();
        mushroomField.Generate();
        gameOver.SetActive(false);
    }

    void GameOver()
    {
        blaster.gameObject.SetActive(false);
        gameOver.SetActive(true);
    }

    public void ResetRound()
    {
        SetLives(lives -1);
        
        if(lives <= 0)
        {
            GameOver();
            return;
        }

        centipede.Respawn();
        blaster.Respawn();
        mushroomField.Heal();
    }

    public void NextLevel()
    {
        centipede.speed *= 1.1f;
        centipede.Respawn();
    }

    public void IncreaseScore(int amount)
    {
        SetScore(score + amount);
    }

    void SetScore(int value)
    {
        score = value;
        scoreText.text = score.ToString();
    }

    void SetLives(int value)
    {
        lives = value;
        livesText.text = lives.ToString();
    }

}
