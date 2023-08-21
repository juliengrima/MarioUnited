using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Falling : MonoBehaviour
{
    #region Champs
    [SerializeField] UnityEvent _invoke;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            _invoke.Invoke();
            //Debug.Log("PARENTS");
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
