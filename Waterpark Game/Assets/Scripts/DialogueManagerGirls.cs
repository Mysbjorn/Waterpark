using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManagerGirls : MonoBehaviour
{
    public NPC npc1;

    bool isTalking1 = false;

    float distance1;
    float curResponseTracker1 = 0;

    public GameObject player1;
    public GameObject dialgogueUI1;

    public TextMeshProUGUI npcName1;
    public TextMeshProUGUI dialogueBox1;
    public TextMeshProUGUI playerResponse1;
    public GameObject npcCam1;
    public GameObject talkUI;
   

    private void Start()
    {
        dialgogueUI1.SetActive(false);
        talkUI.SetActive(false);
    }

    private void OnMouseOver()
    {
        distance1 = Vector3.Distance(player1.transform.position, this.transform.position);
        if (distance1 <= 3.5f)
        {
            talkUI.SetActive(true);
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log("-1");
                curResponseTracker1++;
                if (curResponseTracker1 >= npc1.Playerdialog.Length -1)
                {
                    curResponseTracker1 = npc1.Playerdialog.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                Debug.Log("´+1");
                curResponseTracker1--;
                if (curResponseTracker1 <=0)
                {
                    curResponseTracker1 = 0;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && isTalking1 == false)
            {
                StartConversation1();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking1 == true)
            {
                EndDialogue1();
            }

            if (curResponseTracker1 == 0 && npc1.Playerdialog.Length >= 0)
            {
                playerResponse1.text = npc1.Playerdialog[0];
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueBox1.text = npc1.dialog[1];
                    Debug.Log("Derp");
                }
            }
            else if (curResponseTracker1 == 1 && npc1.Playerdialog.Length >= 1)
            {
                playerResponse1.text = npc1.Playerdialog[1];
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueBox1.text = npc1.dialog[2];
                }
            }
        }
        else
        {
            talkUI.SetActive(false);
        }
    }


    void StartConversation1()
    {
        npcCam1.SetActive(true);
        isTalking1 = true;
        curResponseTracker1 = 0;
        dialgogueUI1.SetActive(true);
        npcName1.text = npc1.name;
        dialogueBox1.text = npc1.dialog[0];
        PlayerController.instance.charController.enabled = false;
        talkUI.SetActive(false);
    }

    void EndDialogue1()
    {
        npcCam1.SetActive(false);
        isTalking1 = false;
        dialgogueUI1.SetActive(false);
        PlayerController.instance.charController.enabled = true;

    }
}
