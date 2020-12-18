using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndSeek : MonoBehaviour
{
    public int value;
    public int soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddhideAndSeekers(value);
            Destroy(gameObject);
            Debug.Log("Found ya!");
            //AudioManager.instance.PlaySFX(soundToPlay);
        }
    }
}
