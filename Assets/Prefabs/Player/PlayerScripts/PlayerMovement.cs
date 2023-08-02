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
    [SerializeField] InputActionReference _jump;

    [Header("Animations")]

    [Header("Fields")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    //[SerializeField] LayerMask _ground;
    bool _isGrounded;
    #endregion
    #region Instances
    private void Reset()
    {
        _speed = 5f;
        _jumpForce = 10f;
    }
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
        HoreizontalMouvements();
        Jump();
        //Debug.Log($"Valeur de _isGrounded : {_isGrounded}");
    }
    #endregion
    #region Methods
    void HoreizontalMouvements()
    {
        float xAxis = _move.action.ReadValue<Vector2>().x * _speed;
        _rb.velocity = new Vector2(xAxis , _rb.velocity.y);
    }
    void Jump()
    {
        bool isButtonPressed;
        isButtonPressed = _jump.action.WasPressedThisFrame();
        if (_isGrounded)  
        {
            //Debug.Log("IS PRESSED");
            if (isButtonPressed)
            {
                _rb.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            //Debug.Log("IT'S GROUNDED");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
            //Debug.Log("IT'S NOT GROUNDED");
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
