using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] Rigidbody m_rb;
    public Rigidbody CoinRB { get => m_rb; } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameArea")
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "GameArea")
        {
            gameObject.SetActive(false);
        }
    }
}
