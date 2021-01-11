using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndSeek : MonoBehaviour
{
    public int value;
    public AudioSource soundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddhideAndSeekers(value);
            Destroy(gameObject);
            soundEffect.Play();

        }
    }
}
