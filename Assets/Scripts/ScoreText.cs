using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    Text[] m_viewText = default;
    [SerializeField]
    float m_viewTime = 0.8f;
    float m_viewTimer = default;
    public void ViewScore(int score)
    {
        GameManager.Instance.AddScore(score);
        foreach (var item in m_viewText)
        {
            item.text = "+" + score;
        }
        m_viewTimer = m_viewTime;
        StartCoroutine(View());
    }
    IEnumerator View()
    {
        while (m_viewTimer > 0)
        {
            m_viewTimer -= Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
