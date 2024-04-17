using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    
    public static GameController Instance;

    const float GAME_TIME = 60f;

    [SerializeField] private VRButton _startButton;

    private int _score;
    private int _highScore = 0;

    private float _time;

    private bool _isActive;

    private void Awake() 
    {
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
    }

    private void Update()
    {
        if (!_isActive) return;
        _time -= Time.deltaTime;

        if (_time <= 0 )
        {
            _time = 0;
            _isActive = false;
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
}
