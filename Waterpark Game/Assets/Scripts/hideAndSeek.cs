using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndSeek : MonoBehaviour
{
    public int value;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddhideAndSeekers(value);
            Destroy(gameObject);
            Debug.Log("Found ya!");
        }
    }
}
