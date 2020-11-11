using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInventoryItem
{
    // item addtibuild name image and use Effect

    public string _name = "item";
    public Sprite _image;
   

    public string Name
    {
        get { return _name; }
    }
    public Sprite Image
    {
        get { return _image; }
    }
    public InventorySlot Slot
    {
        get; set;
    }
    
    public void OnPickup()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);
    }

    public virtual void OnUse()
    {

        print("item =" + PlayCtrl.NowitemUse);

        switch (PlayCtrl.NowitemUse)
        {
            case "FIRST_AID (Item)":
                LifePoint.BloodLife += 1;
                break;

            case "GRENADES (Item)":
                Shoot.IsThrowinggrenades = true;
                break;
            case "MAX (Item)":
                Debug.Log("Max");
                break;
        }


    }
}

