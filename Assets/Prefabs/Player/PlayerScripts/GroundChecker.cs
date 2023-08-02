using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    #region Champs
    [SerializeField] bool _isGrounded;
    [SerializeField] int _isGroundedNumber;
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
            if (_isGrounded == false && Time.time > 1f)
            {
                _effect.Invoke();
            }
            _isGrounded = true;
            _isGroundedNumber++;
            //Debug.Log("IT'S GROUNDED");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGroundedNumber--;
            if (_isGroundedNumber <= 0)
            {
                _isGrounded = false;
            }  
            //Debug.Log("IT'S NOT GROUNDED");
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
