using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour {

    [SerializeField] private float _deadTime = 1f;

    private bool _deadTimeActive = false;

    public event EventHandler OnPressed, OnReleased;

    IEnumerator WaitForDeadTime() {
        _deadTimeActive = true;
        yield return new WaitForSeconds(_deadTime);
        _deadTimeActive = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Button" && !_deadTimeActive)
        {
            OnPressed?.Invoke(this, EventArgs.Empty);
            Debug.Log("button pressed");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Button" && !_deadTimeActive) { 
            OnReleased?.Invoke(this, EventArgs.Empty);

            Debug.Log("Button released");

            StartCoroutine(WaitForDeadTime());
        }
    }


}
