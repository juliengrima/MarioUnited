using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _respawn;
    [SerializeField] UnityEvent _playerGraphics;
    [SerializeField] int _blinking;
    private Vector3 position;
    #endregion
    #region Unity LifeCycle
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            _player.SetActive(false);
            _player.transform.position = _respawn.transform.position;

            if (_player == false)
            {
                _playerGraphics.Invoke();
            }
            _player.SetActive(true);
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
