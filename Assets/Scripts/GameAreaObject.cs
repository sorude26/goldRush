using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaObject : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameArea")
        {
            gameObject.SetActive(false);
        }
    }
}
