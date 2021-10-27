using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static InputController Instance { get; private set; }
    public event Action OnShot;
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onShot = null;
    public event Action<int> OnMove;
    bool m_move = default;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            var dir = Input.GetAxisRaw("Horizontal");
            if (dir > 0)
            {
                OnMove?.Invoke(1);
            }
            else if (dir < 0)
            {
                OnMove?.Invoke(-1);
            }
            m_move = true;
        }
        else if(m_move)
        {
            m_move = false;
            OnMove?.Invoke(0);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
            OnShot?.Invoke();
            m_onShot?.Invoke();
            OnMove?.Invoke(0);
    }
}
