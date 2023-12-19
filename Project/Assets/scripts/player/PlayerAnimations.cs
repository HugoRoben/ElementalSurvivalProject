// script that manages the animator of the player

using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    int isWalkingHash; 
    private Animator knop;
    private int previousAnimatorStateHash;
    public Camera cam;
    private bool isRolling = false;
    private bool isShooting = false;
    void Start()
    {
        knop = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("MoveForwardAnimation");
        previousAnimatorStateHash = knop.GetCurrentAnimatorStateInfo(0).fullPathHash;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            bool WIsHeld = Input.GetKey(KeyCode.W);
            bool AIsHeld = Input.GetKey(KeyCode.A);
            bool DIsHeld = Input.GetKey(KeyCode.D);
            bool SIsHeld = Input.GetKey(KeyCode.S);
            knop.SetBool("MoveBackAnimation", SIsHeld);
            knop.SetBool("MoveForwardAnimation", WIsHeld);
            knop.SetBool("MoveLeftAnimation", AIsHeld);
            knop.SetBool("MoveRightAnimation", DIsHeld);


            // Choose which shoot animation to play depending on selected attacks
            chooseShootAnimation();

            // Roll animations
            if (Input.GetKeyDown("space") && !isRolling && !isShooting)
            {
                isRolling = true;

                if (AIsHeld) knop.SetTrigger("RollLeft");
                else if (DIsHeld) knop.SetTrigger("RollRight");
                else if (WIsHeld && !AIsHeld && !DIsHeld) knop.SetTrigger("RollForward");
            }

            // Attack animation
            if (Input.GetMouseButtonDown(0) && !isRolling && !isShooting) 
            {
                isShooting = true;
                knop.SetTrigger("CastSpell");
            }
        }
    }

    // This method is called by an Animation Event at the end of the roll animation
    public void OnRollAnimationComplete()
    {
        isRolling = false;
    }

    // function that determines which attack is selected to select the right attack animation
    private void chooseShootAnimation()
    {
        knop.SetBool("WaterAttack", false);
        knop.SetBool("AirAttack", false);
        knop.SetBool("EarthAttack", false);

        switch (inventoryUI.selectedItemIndex)
        {
            case 0:
                knop.SetBool("WaterAttack", true);
                break;
            case 1:
                knop.SetBool("AirAttack", true);
                break;
            case 2:
                knop.SetBool("EarthAttack", true);
                break;
        }
    }

    // Firing the bullets in game
    public GameObject[] bulletPrefabArray;
    public InventoryUI inventoryUI;
    public Transform firePoint;
    public Transform firePointAir;
    public Transform aimpoint;
    public float bulletForce = 10f;
    GameObject bullet;
    // animations event function for firing water and earth bullets
    public void FireBulletFromAnimationEvent()
    {
        bullet = Instantiate(bulletPrefabArray[inventoryUI.selectedItemIndex],
        firePoint.position, firePoint.rotation);
         // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        if (bulletRb != null)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            Vector3 shootDirection;
            // Check is raycast hits enemy, if yes aim at the enemy
            if (Physics.Raycast(ray, out hit)) shootDirection = hit.transform.position - transform.transform.position;
            else shootDirection = transform.forward;

            shootDirection.y = 0f;
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
        isShooting = false;
    }
    // different function for firing air bullets, spawned at a different point
    public void FireAirBulletFromAnimationEvent()
    {
        bullet = Instantiate(bulletPrefabArray[inventoryUI.selectedItemIndex],
        firePointAir.position, firePointAir.rotation);
         // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            Vector3 shootDirection;
            // Check is raycast hits enemy, if yes aim at the enemy
            if (Physics.Raycast(ray, out hit)) shootDirection = hit.transform.position - transform.transform.position;
            else shootDirection = transform.forward;

            shootDirection.y = 0f;
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
        isShooting = false;
    }
}
