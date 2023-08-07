using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
    #region Champs
    //[SerializeField] GameObject _player;
    #endregion
    #region Unity LifeCycle
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            collision.attachedRigidbody.transform.SetParent(transform);
            //Debug.Log("PARENTS");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            collision.attachedRigidbody.transform.SetParent(null);
            //Debug.Log("PAS PARENTS");
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
