using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updraft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Nu simmar du");
            PlayerController.instance.updraft = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hej?!");
            PlayerController.instance.updraft = false;
        }
    }

}
