using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCtrl : MonoBehaviour
{
    public float movespeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    private Animator anim;

    public Inventory inventory;
    public InventorySlot iSlot;
    private IInventoryItem mcurrentItem = null;

    Vector2 movement;
    Vector2 mousePos;

    public static string NowitemUse;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

   

    }

    void FixedUpdate()
    {
   

        if (movement.x != 0 || movement.y != 0)
        {
            MovePos();
            MoveWeaponCheckAnim();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot.ChangWeapon += 1;
            ChageWeaponAnim();
            Debug.Log(Shoot.ChangWeapon);
        }

        if (movement.x == 0 && movement.y == 0)
        {
            WeaponIdelAnim();
        }

    }


    void MovePos()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        rb.rotation = angle;        
    }

    void ChageWeaponAnim()
    {
        switch (Shoot.ChangWeapon)       // chage gun in Various forms
        {

            case 0:
                anim.SetInteger("changewp", 0);
                break;
            case 1:
                anim.SetInteger("changewp", 1);
                break;
            case 2:
                anim.SetInteger("changewp", 2);
                break;
        }
    }

    void MoveWeaponCheckAnim()
    {
        switch (Shoot.ChangWeapon)   // chage animetion Change by weapon
        {
            case 0:
                anim.SetInteger("state", 1);
                break;
            case 1:
                anim.SetInteger("stateii", 1);
                break;
            case 2:
                anim.SetInteger("stateiii", 1);
                break;

        }
    }
    void WeaponIdelAnim()
    {
        switch (Shoot.ChangWeapon) // idel animetion Change by weapon       
        {
            case 0:
                anim.SetInteger("state", 0);
                break;
            case 1:
                anim.SetInteger("stateii", 0);
                break;
            case 2:
                anim.SetInteger("stateiii", 0);
                break;
        }
    }

    public void UseItem()
    {
        IInventoryItem item = inventory.ItemTop();
        print("Used item: " + item);
        
        if (item != null)
        {
            if (mcurrentItem != null)
            {
                DropCurrentItem();
            }
            NowitemUse = item.ToString();
            print("NowitemUseitem =" + NowitemUse);

            inventory.UseItem(item);
            inventory.RemoveItem(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
            print(item);
       
        }
    }
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        if (mcurrentItem != null)
        {
            SetItemActive(mcurrentItem, false);
        }

        IInventoryItem item = e.Item;
        SetItemActive(item, true);
        mcurrentItem = e.Item;
    }

    private void SetItemActive(IInventoryItem item, bool active)
    {
        GameObject currentItem = (item as MonoBehaviour).gameObject.gameObject;
        currentItem.SetActive(active);
    
    }

    public void DropCurrentItem()
    {
        GameObject goItem = (mcurrentItem as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;

    }
    public void DoDropItem()
    {
        // Remove Rigidbody
        Destroy((mcurrentItem as MonoBehaviour).GetComponent<Rigidbody>());
        mcurrentItem = null;
    }
}
