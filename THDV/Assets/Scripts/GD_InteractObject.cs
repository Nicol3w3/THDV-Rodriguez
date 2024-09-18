using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GD_InteractObject : MonoBehaviour
{
   public string interactionText = "Press E to Interact";
   public UnityEvent onInteract;

   public string GetInteractionText()
    {
        return interactionText;
    }

   public void interact()
   {
        onInteract.Invoke();
   }
}
