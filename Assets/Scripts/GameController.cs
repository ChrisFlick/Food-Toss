using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour 
{
    
    public static GameController Instance;

    const float GAME_TIME = 60f;

    [SerializeField] private VRButton _startButton;

    [SerializeField] private TextMeshPro _scoreText;

    private int _score;
    private int _highScore = 0;

    private float _time;

    private bool _isActive;

    private void Awake() 
    {
        // Check to see if there are dublicate instances and if so destroy this one.
        if (Instance != null) 
        {
            Debug.LogError(
                "There's more than one instance of GameController " + transform + "-" + Instance
            );
            Destroy(gameObject);

            return;
        }
        Instance = this;
    }

    private void Start() 
    {
        _startButton.OnPressed += StartButton_OnPressed;

        Target.Instance.OnHit += Target_OnHit;
    }

    private void Update()
    {
        if (!_isActive) return;
        _time -= Time.deltaTime;

        if (_time <= 0 )
        {
            _time = 0;
            _isActive = false;

            if (_score > _highScore)
            {
                _highScore = _score;
            }
        }
    }

    public bool IsActive()
    {
        return _isActive;
    }

    private void StartButton_OnPressed(object sender, EventArgs e) 
    {
        _isActive = true;
        _time = GAME_TIME;
        _score = 0;
    }

    private void Target_OnHit(object sender, EventArgs e)
    {
        if (!_isActive) return;

        _score++;
        _scoreText.text = _score.ToString();
    }
}
