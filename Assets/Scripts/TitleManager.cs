using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
    bool m_load = false;
    private void Start()
    {
        FadeController.Instance.StartFadeIn();
    }
    public void OnClickStart()
    {
        if (m_load)
        {
            return;
        }
        m_load = true;
        FadeController.Instance.StartFadeOut(LoadScene);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Battle");
    }
}
