using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    Rigidbody m_rb;
    public Rigidbody CoinRB { get => m_rb; } 
    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

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
