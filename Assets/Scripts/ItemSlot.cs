using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Image image;

    private InventoryItem _item;

    public InventoryItem Item
    {
        get 
        { 
            return _item;
        }//end get
        set
        {
            _item = value;
            if(_item == null)
            {
                image.enabled = false;

            }
            else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }//end set
    }//end Item property


    private void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        
    }//end OnValidate
}
