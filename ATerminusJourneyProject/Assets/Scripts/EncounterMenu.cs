using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EncounterMenu : MonoBehaviour
{

    public GameObject Canvas;
    public PlayerData playerData;
    public TMP_Text playerName;
    private Animator animator;
    private bool activeMenu = true;
    private bool menuWait = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = Canvas.GetComponent<Animator>();
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
        if (!menuWait) {
            activeMenu = !activeMenu;
            float animationTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            animator.SetBool("activeMenu", activeMenu);
            //float animationTime = animator.GetCurrentAnimatorStateInfo(0).
            StartCoroutine(WaitForSlide());
        }
    }

    private IEnumerator WaitForSlide() {
        menuWait = true;
        yield return new WaitForSeconds(.7f);
        menuWait = false;
    }

}
