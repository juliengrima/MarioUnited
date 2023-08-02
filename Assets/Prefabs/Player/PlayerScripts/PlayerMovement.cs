using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Champs
    [Header("Objects")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _move;

    [Header("Fields")]
    [SerializeField] float _speed;
    [SerializeField] LayerMask _groundMask;
    bool _isGrounded;
    int _jump;
    #endregion
    #region Instances
    public static PlayerMovement Instance
    {
        get; private set;
    }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        HoreizontalMouvements();

    }
    #endregion
    #region Methods
    void HoreizontalMouvements()
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();
        _rb.velocity = direction * _speed;
    }
    void Jump()
    {
        if (_isGrounded)
        {
            if (Input.GetButtonDown("Space"))
            {
                _rb.AddForce(Vector2.up * _jump);
            }
        }

    }

    void OnCollisionEnter(Collision ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            Debug.Log("IT'S GROUNDED");
        }
    }

    void OnCollisionExit(Collision ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            _isGrounded = false;
            Debug.Log("IT'S NOT GROUNDED");
        }
    }

    void FixedUpdate ()
    {
        
    }
    void LateUpdate ()
    {
        
    }
    #endregion
    #region Coroutines
    #endregion
}
