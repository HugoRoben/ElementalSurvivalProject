using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private bool AnimationIsPlaying;
    int isWalkingHash; 
    // private bool AIsHeld;
    // private bool SIsHeld;
    // private bool DIsHeld;

    // Your animator component
    private Animator knop;

    void Start()
    {
        // Assuming your Animator component is attached to the same GameObject as this script
        knop = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("MoveForwardAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        bool MoveForwardAnimation = knop.GetBool(isWalkingHash);
        bool MoveBackAnimation = knop.GetBool("MoveBackAnimation");
        bool MoveLeftAnimation = knop.GetBool("MoveLeftAnimation");
        bool MoveRightAnimation = knop.GetBool("MoveRightAnimation");
        bool WIsHeld = Input.GetKey(KeyCode.W);
        bool AIsHeld = Input.GetKey(KeyCode.A);
        bool DIsHeld = Input.GetKey(KeyCode.D);
        bool SIsHeld = Input.GetKey(KeyCode.S);
        // Check W key input
        if (!MoveForwardAnimation && WIsHeld)
        {
            knop.SetBool(isWalkingHash, true);
        }
        if (MoveForwardAnimation && !WIsHeld)
        {
            knop.SetBool(isWalkingHash, false);
        }
        if (!MoveLeftAnimation && AIsHeld)
        {
            knop.SetBool("MoveLeftAnimation", true);
        }
        if (MoveLeftAnimation && !AIsHeld)
        {
            knop.SetBool("MoveLeftAnimation", false);
        }
        if (!MoveRightAnimation && DIsHeld)
        {
            knop.SetBool("MoveRightAnimation", true);
        }
        if (MoveRightAnimation && !DIsHeld)
        {
            knop.SetBool("MoveRightAnimation", false);
        }
        if (!MoveBackAnimation && SIsHeld)
        {
            knop.SetBool("MoveBackAnimation", true);
        }
        if (MoveBackAnimation && !SIsHeld)
        {
            knop.SetBool("MoveBackAnimation", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            knop.SetTrigger("CastSpell");
        }
    }
        
}
