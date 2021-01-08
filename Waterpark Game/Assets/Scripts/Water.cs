using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerController1.instance.swimming == false)
        {
            Debug.Log("Nu simmar du");
            PlayerController1.instance.swimming = true;
        }

        else if (other.tag == "Player" && PlayerController1.instance.swimming == true)
        {
            PlayerController1.instance.swimming = false;
        }
    
    }

    

}
