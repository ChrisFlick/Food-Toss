using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTarget : MonoBehaviour {

    const int MAX_DISTANCE = 3;

    [SerializeField] private float _speed = 1;
    
    private bool _active = false;
    private int _direction = 1;

    private void Start()
    {
        _active = true;
    }

    private void Update() {
        if (!_active) return;

        transform.localPosition = new Vector3(
            transform.localPosition.x + _speed * Time.deltaTime * _direction,
            transform.localPosition.y,
            transform.localPosition.z);

        if (Mathf.Abs(transform.localPosition.x) >= MAX_DISTANCE) {
            transform.localPosition = new Vector3(
                MAX_DISTANCE * _direction,
                transform.localPosition.y,
                transform.localPosition.z);

            _direction *= -1;
        }
    }
}
