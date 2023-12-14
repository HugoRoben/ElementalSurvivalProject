using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    int isWalkingHash; 
    private Animator knop;
    private int previousAnimatorStateHash;
    public Camera cam;
    void Start()
    {
        knop = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("MoveForwardAnimation");
        previousAnimatorStateHash = knop.GetCurrentAnimatorStateInfo(0).fullPathHash;

    }

    // Update is called once per frame
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
        chooseShootAnimation();
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
            Frames(5);
    
        }
    }

    private void chooseShootAnimation()
    {
        if (inventoryUI.selectedItemIndex == 0)
        {
            knop.SetBool("WaterAttack", true);
            knop.SetBool("AirAttack", false);
            knop.SetBool("EarthAttack", false);
        }
        if (inventoryUI.selectedItemIndex == 1)
        {
            knop.SetBool("WaterAttack", false);
            knop.SetBool("AirAttack", true);
            knop.SetBool("EarthAttack", false);
        }
        if (inventoryUI.selectedItemIndex == 2)
        {
            knop.SetBool("WaterAttack", false);
            knop.SetBool("AirAttack", false);
            knop.SetBool("EarthAttack", true);
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
    public Transform firePointAir;
    public Transform aimpoint;
    public float bulletForce = 10f;
    GameObject bullet;
    

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
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            Vector3 shootDirection;

            if (Physics.Raycast(ray, out hit))
            {
                shootDirection = hit.transform.position - transform.transform.position;
            }
            else
            {
                shootDirection = transform.forward;
            }
            shootDirection.y = 0f;
            // Apply velocity to the bullet in the forward direction
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
    }
    public void FireAirBulletFromAnimationEvent()
    {
        
        bullet = Instantiate(bulletPrefabArray[inventoryUI.selectedItemIndex],
        firePointAir.position, firePointAir.rotation);
         // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        

        // Check if the bullet's Rigidbody component exists
        if (bulletRb != null)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            Vector3 shootDirection;

            if (Physics.Raycast(ray, out hit))
            {
                shootDirection = hit.transform.position - transform.transform.position;
            }
            else
            {
                shootDirection = transform.forward;
            }
            shootDirection.y = 0f;
            // Apply velocity to the bullet in the forward direction
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
    }
        
}
