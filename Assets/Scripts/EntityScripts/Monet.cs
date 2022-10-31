using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singletone.MonetChange(-1);
        Destroy(gameObject);
    }
}
