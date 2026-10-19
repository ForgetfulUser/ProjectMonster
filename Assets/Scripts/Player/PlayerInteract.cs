using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public IInteractable Interactable;
    public PlayerController PlayerController;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Interactable != null && PlayerController.enabled)
        {
            Interactable.Interact();
            PlayerController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
