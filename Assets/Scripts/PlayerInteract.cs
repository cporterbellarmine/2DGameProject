using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject currentInterObj = null;

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if(currentInterObj.name == "BreadStall")
                currentInterObj.SendMessage("DoSellInteraction", "bread", );

            if (currentInterObj.name == "BeetStall")
                currentInterObj.SendMessage("DoSellInteraction", "beet", );

            if (currentInterObj.name == "AppleStall")
                currentInterObj.SendMessage("DoSellInteraction", "apple", );

            if (currentInterObj.name == "CarrotStall")
                currentInterObj.SendMessage("DoSellInteraction", "carrot", );

            if (currentInterObj.name == "BananaStall")
                currentInterObj.SendMessage("DoSellInteraction", "banana", );

            if (currentInterObj.name == "PeaStall")
                currentInterObj.SendMessage("DoSellInteraction", "pea", );

            if (currentInterObj.name == "PepperStall")
                currentInterObj.SendMessage("DoSellInteraction", "pepper", );

            if (currentInterObj.name == "BookStall")
                currentInterObj.SendMessage("DoSellInteraction", "book", );

            if (currentInterObj.name == "OrangeStall")
                currentInterObj.SendMessage("DoSellInteraction", "orange", );

            if (currentInterObj.name == "CornStall")
                currentInterObj.SendMessage("DoSellInteraction", "corn", );
        }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactible"))
        {
            Debug.Log(collision.name);
            currentInterObj = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider other)
    {
        if (other.CompareTag("Interactible"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
