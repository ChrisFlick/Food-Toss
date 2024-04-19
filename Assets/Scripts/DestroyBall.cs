using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.gameObject.tag != "Ball") return;

        Destroy(collision.rigidbody.gameObject);
    }
}
