using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private VRButton _spawnButton;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Transform _ballPrefab;

    private void Start()
    {
        _spawnButton.OnPressed += SpawnButton_OnPressed;
    }

    private void SpawnButton_OnPressed(object sender, EventArgs e)
    {
        Instantiate(_ballPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
