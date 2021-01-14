using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;


    private void Start()
    {
        StartCoroutine(Type());
        StartCoroutine(timedSpeech());

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }

    IEnumerator timedSpeech()
    {
        yield return new WaitForSeconds(150f);
        NextSentence();
        yield return new WaitForSeconds(150f);
        NextSentence();
        yield return new WaitForSeconds(150f);
        NextSentence();
        yield return new WaitForSeconds(150f);
        NextSentence();
        yield return new WaitForSeconds(150f);
        NextSentence();
        yield return new WaitForSeconds(150f);
        NextSentence();
    }
}
