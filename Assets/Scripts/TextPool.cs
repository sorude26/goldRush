using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPool : MonoBehaviour
{
    public static TextPool Instance { get; private set; }
    [SerializeField]
    int m_maxCount = 20;
    [SerializeField]
    ScoreText m_prefab = default;
    ScoreText[] m_allObject = default;
    private void Awake()
    {
        Instance = this;
        m_allObject = new ScoreText[m_maxCount];
        for (int i = 0; i < m_maxCount; i++)
        {
            var score = Instantiate(m_prefab);
            score.transform.SetParent(transform);
            m_allObject[i] = score;
            score.gameObject.SetActive(false);
        }
    }
    public void CallScore(Vector3 pos)
    {
        foreach (var score in m_allObject)
        {
            if (score.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                score.transform.position = pos;
                score.gameObject.SetActive(true);
                score.transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
        }
    }
    public ScoreText GetScore(Vector3 pos)
    {
        foreach (var score in m_allObject)
        {
            if (score.gameObject.activeSelf)
            {
                continue;
            }
            else
            {
                score.transform.position = pos;
                score.gameObject.SetActive(true);
                return score;
            }
        }
        return null;
    }
}
