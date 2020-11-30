﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    private void Awake()
    {
        instance = this;  
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
        Debug.Log("Derp");
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.theCMBrain.enabled = false;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(2f);
        HealthManager.instance.ResetHealth();
        UIManager.instance.fadeFromBlack = true;
        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.theCMBrain.enabled = true;
        PlayerController.instance.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }
}