using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager_ : MonoBehaviour
{
    public static GameManager_ instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;      // Text mesh pro ������Ʈ ����� ���
    public TMP_Text coinText;
    //public Text scoreText_;         // Legacy text ������Ʈ ����� ���
    public GameObject gameoverUi;

    private int score = 0;
    private int coin = 0;

    private void Awake()
    {
        if (instance.isValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver == true && Input.GetMouseButton(0))
        {
            //GFunc.LoadScene("PlayScene");
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    public void AddCoin(int newCoin)
    {
        if (isGameOver == false)
        {
            coin += newCoin;
            coinText.text = string.Format("Coin : {0}", coin);
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }
}
