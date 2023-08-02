using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GroundChecker : MonoBehaviour
{
    #region Champs
    [SerializeField] bool _isGrounded;
    [SerializeField] UnityEvent _effect;

    public bool IsGrounded { get => _isGrounded; }
    #endregion
    #region Unity LifeCycle
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _effect.Invoke();
            //Debug.Log("IT'S GROUNDED");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
            //Debug.Log("IT'S NOT GROUNDED");
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
