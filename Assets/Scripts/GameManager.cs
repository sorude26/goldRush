using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    Text m_shotCount = default;
    [SerializeField]
    Text m_scoreCount = default;
    [SerializeField]
    GameObject[] m_life = default;
    [SerializeField]
    GameObject m_gameOver = default;
    [SerializeField]
    DragonController m_dragons = default;
    public int Count { get; private set; }
    [SerializeField]
    int m_startCoin = 100;
    [SerializeField]
    int m_addCount = 20;
    int m_count = 0;
    int m_score = 0;
    int m_lifeCount = 0;
    [SerializeField]
    RankingController m_rankingPrefab = default;
    private void Awake()
    {
        Instance = this;
        Count = m_startCoin;
    }
    private void Start()
    {
        FadeController.Instance.StartFadeIn();
    }
    public void AddShot()
    {
        if (Count > 1)
        {
            Count -= 2;
            m_shotCount.text = $"Coin:{Count}";
        }
        else
        {
            m_dragons.AddDragon();
        }
    }
    public void UpdateCount()
    {
        Count++;
        m_shotCount.text = $"Coin:{Count}";
        m_count++;
        if (m_count > m_addCount)
        {
            m_dragons.AddDragon();
            m_count = 0;
        }
    }
    public void AddScore(int score)
    {
        m_score += score;
        m_scoreCount.text = $"SCORE:{m_score}";
    }
    public void Damage()
    {
        if (m_lifeCount >= m_life.Length)
        {
            return;
        }
        if (m_lifeCount < m_life.Length) 
        {
            m_life[m_lifeCount].SetActive(false);
            m_lifeCount++;
        }
        if (m_lifeCount >= m_life.Length)
        {
            m_gameOver.SetActive(true);
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(4f);
        m_rankingPrefab.gameObject.SetActive(true);
        m_rankingPrefab.SetScoreOfCurrentPlay(m_score);
    }
    public void LoadScene()
    {
        CoinPool.Instance.DestroyAll();
        ShotPool.Instance.DestroyAll();
        TextPool.Instance.DestroyAll();
        SceneManager.LoadScene("Title");
    }
}
