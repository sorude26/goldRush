using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using Unity.Collections;

public class RankingController : MonoBehaviour
{
    [SerializeField]
    Text m_rankingNameText = default;
    [SerializeField]
    Text m_rankingScoreText = default;
    [SerializeField]
    InputField m_nameInput = default;
    [SerializeField]
    RectTransform m_entryPanel = default;
    [SerializeField]
    RectTransform m_limitMassagePanel = default;
    [SerializeField]
    float m_gracePeriod = 10f;
    float m_timer;
    List<NCMBObject> m_ranking = default;
    int m_score;
    bool m_closable = false;
    bool m_load = false;
    void Update()
    {
        if (!m_closable)
        {
            m_timer += Time.deltaTime;

            if (m_timer > m_gracePeriod)
            {
                m_closable = true;
            }
        }
    }
    public void CloseRanking()
    {
        if (m_load)
        {
            return;
        }
        if (m_closable && !m_entryPanel.gameObject.activeSelf) 
        {
            m_load = true;
            m_ranking.Clear();
            FadeController.Instance.StartFadeOut(GameManager.Instance.LoadScene);
        }
    }
    public void CloseInput()
    {
        m_entryPanel.gameObject.SetActive(false);
    }
    public void CloseMassage()
    {
        m_limitMassagePanel.gameObject.SetActive(false);
    }
    public void GetRanking(int score)
    {
        m_score = score;

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("HighScore");
        query.OrderByDescending("Score");
        query.Limit = 7;
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e.ToString());
            }
            else
            {
                m_ranking = objList;
                MakeRankingText();

                if ((score > 0 && m_ranking.Count < 7) || score > int.Parse(m_ranking[m_ranking.Count - 1]["Score"].ToString()) || m_ranking.Count == 0)
                {
                    m_entryPanel.gameObject.SetActive(true);
                }
            }
        });
    }
    void MakeRankingText()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        System.Text.StringBuilder builderScore = new System.Text.StringBuilder();
        for (int i = 0; i < m_ranking.Count; i++)
        {
            builder.Append((i + 1).ToString());
            builder.Append(" : ");
            builder.AppendLine(m_ranking[i]["Name"].ToString());
            builderScore.AppendLine(m_ranking[i]["Score"].ToString());
        }
        m_rankingNameText.text = builder.ToString();
        m_rankingScoreText.text = builderScore.ToString();
    }
    public void SetScoreOfCurrentPlay(int score)
    {
        GetRanking(score);
    }
    public void Entry()
    {
        if (m_nameInput.text.Length > 10)
        {
            m_limitMassagePanel.gameObject.SetActive(true);
            return;
        }
        if (m_nameInput.text.Length <= 0)
        {
            return;
        }
        NCMBObject obj = new NCMBObject("HighScore");
        obj["Name"] = m_nameInput.text;
        obj["Score"] = m_score;

        obj.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogError(e.ToString());
            }
            else
            {
                m_entryPanel.gameObject.SetActive(false);
                GetRanking(0);
            }
        });
    }
}
