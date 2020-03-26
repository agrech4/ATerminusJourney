using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EncounterMenu : MonoBehaviour
{

    public GameObject encounterMenu;
    public PlayerData playerData;
    public TMP_Text playerName;


    // Start is called before the first frame update
    void Start()
    {
        playerName.text = playerData.charName;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu")) {
            ToggleMenu();
        }
    }



    void ToggleMenu() {
        encounterMenu.SetActive(!encounterMenu.activeInHierarchy);
    }


}
