using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Champs
    int _score = 0;
    [SerializeField] TextMeshProUGUI _scoreText;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    public static ScoreManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    #endregion
    #region Methods
    internal void AddScore(int amount)
    {
        _score += amount;
        _scoreText.text = _score.ToString();
        //Debug.Log($" Death count : {_score}");
    }
    internal void DeleteScore(int amount)
    {
        _score -= amount;
        _scoreText.text = _score.ToString();

        //Debug.Log($" PlayerDeath count : {_score}");
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
