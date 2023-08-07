using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _player;
    private Vector3 position;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    //void Awake()
    //{

    //}
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            _player.SetActive(false);
            _player.transform.position = transform.position.Set(90, 1, 0);
        }
    }
    //void FixedUpdate ()
    //{

    //}
    //void LateUpdate ()
    //{

    //}
    #endregion
    #region Coroutines
    #endregion
}
