using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] int _life = 40;
    [SerializeField] UnityEvent _onPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Component
        if (collision.attachedRigidbody == null) return;
        //PlayerTag tag = collision.attachedRigidbody.gameObject.GetComponent<PlayerTag>();
        if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {  
            var life = collision.attachedRigidbody.gameObject.GetComponent<Health>();
            life.GiveLife(_life);
            _onPicked.Invoke();
        }
    }
}
