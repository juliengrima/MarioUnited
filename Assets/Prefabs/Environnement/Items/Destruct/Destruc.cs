using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruc : MonoBehaviour
{
    #region Champs
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprite = new Sprite[2]; // Liste d'armes
    //[SerializeField] AudioClip[] _audio = new AudioClip[2]; // Liste d'armes

    AudioSource _source;

    int _currentSprite;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        _spriteRenderer.sprite = _sprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Methods
    void FixedUpdate ()
    {
        
    }
    void LateUpdate ()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentSprite++;

        if (_currentSprite >= _sprite.Length)
        {
            //_source.PlayOneShot(_audio[1]);
            gameObject.SetActive(false);
        }
        else
        {
            //_source.PlayOneShot(_audio[2]);
            _spriteRenderer.sprite = _sprite[_currentSprite];
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
