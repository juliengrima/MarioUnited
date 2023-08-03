using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Champs
    [Header("Objects")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _jump;
    [SerializeField] UnityEvent _sound;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject graphics;

    //[SerializeField] GroundChecker _isGrounded;

    [Header("Animations")]

    [Header("Fields")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    //[SerializeField] LayerMask _ground;
    bool _isButtonPressed;
    bool isGrounded;
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
        _animator.SetFloat("Speed", Mathf.Abs(xAxis));
        Debug.Log($"Definition de l'axe de déplacement : {xAxis}");

        if (xAxis < 0)
        {
            float sprites = graphics.transform.rotation.y;
            sprites = 180f;
        }
    }
    void Jump()
    {
        _isButtonPressed = _jump.action.WasPressedThisFrame();
        isGrounded = gameObject.GetComponentInChildren<GroundChecker>().IsGrounded;
        if (isGrounded)
        {
            //Debug.Log("IS PRESSED");
            if (_isButtonPressed)
            {
                _rb.AddForce(Vector2.up * _jumpForce);
                _sound.Invoke();
            }
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
