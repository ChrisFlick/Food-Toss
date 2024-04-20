using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public static Target Instance { get; private set; }

    public event EventHandler OnHit;

    private void Awake()
    {
        // Check to see if there are dublicate instances and if so destroy this one.
        if (Instance != null)
        {
            Debug.LogError(
                "There's more than one instance of Target " + transform + "-" + Instance
            );
            Destroy(gameObject);

            return;
        }
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Target Hit");
        if (other.gameObject.tag != "Ball") return;
        Debug.Log("Ball");

        OnHit?.Invoke(this, EventArgs.Empty);
    }
}
