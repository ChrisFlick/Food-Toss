using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTarget : MonoBehaviour {

    const int MAX_DISTANCE = 3;

    [SerializeField] private float _speed = 1;
    
    private bool _active = false;
    private int _direction = 1; // Changes between -1  and +1 to deside which direction the target will move.

    private void Start()
    {
        _active = true;
    }

    private void Update() 
    {
        // If the game is active move the target left or right.
        if (!GameController.Instance.IsActive()) return;

        transform.localPosition = new Vector3(
            transform.localPosition.x + _speed * Time.deltaTime * _direction,
            transform.localPosition.y,
            transform.localPosition.z);
        
        // Change direction once the target reaches the max distance.
        if (Mathf.Abs(transform.localPosition.x) >= MAX_DISTANCE) 
        {
            transform.localPosition = new Vector3(
                MAX_DISTANCE * _direction,
                transform.localPosition.y,
                transform.localPosition.z);

            _direction *= -1;
        }
    }
}
