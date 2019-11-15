using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBehavior : MonoBehaviour {

    public bool dialogueActive;
    public bool playerInRange;
    public string dialogue;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (playerInRange && Input.GetButtonDown("Interact")) {
            ToggleDialogue();
        }
    }

    public void ToggleDialogue() {
        if (dialogue.Length > 0) {
            dialogueBox.SetActive(!dialogueActive);
            if (!dialogueActive) dialogueText.SetText(dialogue);
            dialogueActive = !dialogueActive;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
            if (dialogueActive) ToggleDialogue();
        }
    }
}
