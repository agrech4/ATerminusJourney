using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    public EncounterMenu script;

    public void SelectButton() {
        script.SetActiveButton();
    }
}
