using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Beer : MonoBehaviour
{
    #region Champs
    [SerializeField] int _points;
    [SerializeField] UnityEvent _onPick;

    public int Points { get => _points; }
    #endregion
    #region Unity LifeCycle
    
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //var playerTag = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
        {
            _onPick.Invoke();
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
