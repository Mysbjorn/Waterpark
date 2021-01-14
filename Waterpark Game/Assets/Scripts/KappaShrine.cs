using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaShrine : MonoBehaviour
{
    public int value;
    public int soundToPlay;
    public Transform position;
    public GameObject pickupEffect;
    public AudioSource soundEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddkappaShrines(value);

            Destroy(gameObject);
            Instantiate(pickupEffect, position.position, transform.rotation);
            soundEffect.Play();
        }
    }
}
