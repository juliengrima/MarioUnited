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
    [SerializeField] InputActionReference _shoot;
    [SerializeField] UnityEvent _sound;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject graphics;

    [Header("Animations")]

    [Header("Fields")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

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
    // Update is called once per frame
    void Update()
    {
        float xAxis = _move.action.ReadValue<Vector2>().x * _speed;
        _animator.SetBool("IsJumping", false);
        HoreizontalMouvements(xAxis);
        Animators(xAxis);
        UpdateRotation(xAxis);
        Jump();
        //Debug.Log($"Valeur de _isGrounded : {_isGrounded}");
    }
    #endregion
    #region Methods
    void HoreizontalMouvements(float xAxis)
    {      
        _rb.velocity = new Vector2(xAxis, _rb.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xAxis));
        //Debug.Log($"Definition de l'axe de déplacement : {xAxis}");
     
    }

    void Jump()
    {
        _isButtonPressed = _jump.action.WasPressedThisFrame();
        //_isButtonPressed = _jump.action.IsPressed();
        isGrounded = gameObject.GetComponentInChildren<GroundChecker>().IsGrounded;
        if (isGrounded)
        {
           
            //Debug.Log("IS PRESSED");
            if (_isButtonPressed)
            {
                _rb.AddForce(Vector2.up * _jumpForce);
                _sound.Invoke();
                _animator.SetBool("IsJumping", true);
            }
        }
    }
    void Shoot()
    {
        _isButtonPressed = _shoot.action.WasPressedThisFrame();
        //Debug.Log("IS PRESSED");
        if (_isButtonPressed)
        {
            //_rb.AddForce(Vector2.up * _jumpForce);
            _sound.Invoke();
            _animator.SetBool("IsShooting", true);
        }
        
    }

    private void Animators(float xAxis)
    {
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    private void UpdateRotation(float xAxis)
    {
        if (xAxis > 0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xAxis < 0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }  
    }
    #endregion
    #region Coroutines
    #endregion
}
