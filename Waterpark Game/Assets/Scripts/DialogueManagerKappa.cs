using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManagerKappa : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialgogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI dialogueBox;
    public TextMeshProUGUI playerResponse;
    public GameObject npcCam;
    public GameObject endCam;
    public GameObject UI;
    public GameObject head;
    public bool gamefinished = false; 

    private void Start()
    {
        dialgogueUI.SetActive(false);

    }

    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 3.5f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log("-1");
                curResponseTracker++;
                if (curResponseTracker >= npc.Playerdialog.Length -1)
                {
                    curResponseTracker = npc.Playerdialog.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                Debug.Log("´+1");
                curResponseTracker--;
                if (curResponseTracker <=0)
                {
                    curResponseTracker = 0;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true && gamefinished == false)
            {
                EndDialogue();
            }

            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true && gamefinished == true)
            {
                EndGame();
            }

            if (curResponseTracker == 0 && npc.Playerdialog.Length >= 0)
            {
                playerResponse.text = npc.Playerdialog[0];
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueBox.text = npc.dialog[1];
                    Debug.Log("Derp");
                }
            }
            else if (curResponseTracker == 1 && npc.Playerdialog.Length >= 1)
            {
                playerResponse.text = npc.Playerdialog[1];
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueBox.text = npc.dialog[2];
                }
            }

            else if (curResponseTracker == 3 && npc.Playerdialog.Length >= 3)
            {
                playerResponse.text = npc.Playerdialog[3];
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueBox.text = npc.dialog[5];
                }
            }
            else if (curResponseTracker == 2 && npc.Playerdialog.Length >= 2)
            {
                playerResponse.text = npc.Playerdialog[2];
                if (Input.GetKeyDown(KeyCode.R) && GameManager.instance.kappaShrines == 4)
                {
                    gamefinished = true;
                    dialogueBox.text = npc.dialog[4];
                    head.SetActive(false);
                    

                }

                if (Input.GetKeyDown(KeyCode.R) && GameManager.instance.kappaShrines < 4)
                {
                    dialogueBox.text = npc.dialog[3];
                    Debug.Log("Come back when u got all the shrines");

                }

               
            }
        }
    }

    void StartConversation()
    {
        npcCam.SetActive(true);
        isTalking = true;
        curResponseTracker = 0;
        dialgogueUI.SetActive(true);
        npcName.text = npc.name;
        dialogueBox.text = npc.dialog[0];
        PlayerController.instance.charController.enabled = false;

    }

    void EndDialogue()
    {
        npcCam.SetActive(false);
        isTalking = false;
        dialgogueUI.SetActive(false);
        PlayerController.instance.charController.enabled = true;

    }

    void EndGame()
    {
        UI.SetActive(false);
        endCam.SetActive(true);
    }
}
