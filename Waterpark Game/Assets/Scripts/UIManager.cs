using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image blackScreen;
    public Image swimScreen;
    public float FadeSpeed = 1.5f;
    public bool fadeToBlack, fadeFromBlack;
    public TextMeshProUGUI healthText;
    public Image healthImage;
    public TextMeshProUGUI coinText;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        swimScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, FadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, FadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }

        if (PlayerController.instance.swimming == true)
        {
            swimScreen.enabled = true;


        }

        if (PlayerController.instance.swimming == false)
        {
            swimScreen.enabled = false;


        }
    }

}
