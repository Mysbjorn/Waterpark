using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    public Material material;
    public GameObject girlMesh;
    public int cost;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.currentCoins >= cost)
        {
            Debug.Log("fittslem");
            girlMesh.GetComponent<SkinnedMeshRenderer>().material = material;
        }
    }
}
