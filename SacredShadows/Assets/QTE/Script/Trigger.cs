using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent;
    [SerializeField] UnityEvent onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent.Invoke();
    }
}
