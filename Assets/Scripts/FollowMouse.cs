using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
   
    private void Update()
    {
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        gameObject.transform.position = screenToWorldPointPosition;
    }
}
