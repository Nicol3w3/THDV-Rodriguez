using UnityEngine;
using TMPro;

public class GD_PlaterInteract : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDistance = 3f;
    public GameObject interactionText;
    private GD_InteractObject currentInteractable;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            GD_InteractObject interactableObject = hit.collider.GetComponent<GD_InteractObject>();
            if(interactableObject !=null && interactableObject != currentInteractable)
            {
                currentInteractable = interactableObject;
                interactionText.SetActive(true);
                TextMeshProUGUI textComponent = interactionText.GetComponent<TextMeshProUGUI>();
                if(textComponent!=null)
                {
                    textComponent.text = currentInteractable.GetInteractionText();
                }
                
            }
        }

        else
        {
            currentInteractable = null;
            interactionText.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable?.interact();
        }
    }
}
