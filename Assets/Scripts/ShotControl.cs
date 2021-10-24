using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField]
    float m_shotPower = 5f;
    [SerializeField]
    Transform m_tartget = default;
    [SerializeField]
    Transform m_muzzel = default;
    private void Start()
    {
        if (InputController.Instance)
        {
            InputController.Instance.OnShot += Shot;
        }
    }
    public void Shot()
    {
        if (GameManager.Instance.Count < 2)
        {
            return;
        }
        Vector3 dir = m_tartget.position - m_muzzel.position;
        var coin = CoinPool.Instance.ShotCoin(m_muzzel.position);
        if (coin)
        {
            //coin.transform.rotation = Quaternion.Euler(0, 0, 90);
            coin.transform.rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 0, 90);
            //Transform.LookAt(m_tartget, Vector3.up);
            coin.CoinRB.AddForce(new Vector3(0, 0.3f, 1) + dir.normalized * m_shotPower, ForceMode.Impulse);
            coin.CoinRB.AddRelativeForce(dir);
        }
    }
}
