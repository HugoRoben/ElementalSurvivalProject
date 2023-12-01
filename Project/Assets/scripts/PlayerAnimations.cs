using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private bool AnimationIsPlaying;
    int isWalkingHash; 
    private Animator knop;
    private int previousAnimatorStateHash;

    void Start()
    {
        knop = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("MoveForwardAnimation");
        previousAnimatorStateHash = knop.GetCurrentAnimatorStateInfo(0).fullPathHash;

    }

    // Update is called once per frame
    Transform currentTransformPlayer;
    void Update()
    {
        bool MoveForwardAnimation = knop.GetBool(isWalkingHash);
        bool MoveBackAnimation = knop.GetBool("MoveBackAnimation");
        bool MoveLeftAnimation = knop.GetBool("MoveLeftAnimation");
        bool MoveRightAnimation = knop.GetBool("MoveRightAnimation");
        bool SpellOver = knop.GetBool("SpellOver");
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
        if (Input.GetKey("space"))
        {
            knop.SetTrigger("CastSpell");
            Frames(5);
    
        }
    }
    IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
        knop.ResetTrigger("Castspell");
    }


    public GameObject[] bulletPrefabArray;
    public InventoryUI inventoryUI;
    public Transform firePoint;
    public Transform aimpoint;
    public float bulletForce = 10f;
    GameObject bullet;
    // public void BulletSpawnfromAnimationEvent()
    // {
    //     // Instantiate a new bullet at the firePoint position and rotation

    // }
    // This function will be called from the Animation Event
    public void FireBulletFromAnimationEvent()
    {
        bullet = Instantiate(bulletPrefabArray[inventoryUI.selectedItemIndex],
        firePoint.position, firePoint.rotation);
         // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Check if the bullet's Rigidbody component exists
        if (bulletRb != null)
        {
            Vector3 shootDirection = transform.forward;
            shootDirection.y = 0f;
            // Apply velocity to the bullet in the forward direction
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
    }
        
}
