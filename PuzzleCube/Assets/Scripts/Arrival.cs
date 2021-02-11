using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrival : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
        }
    }
}
