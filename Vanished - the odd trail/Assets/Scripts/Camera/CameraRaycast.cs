using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField]
    private float range;

    private IInteractable currentTarget;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForInteractable();

        if (Input.GetAxisRaw("Interact") > 0)
        {
            if(currentTarget != null)
            {
                currentTarget.OnInteraction();
            }
        }
    }

    private void RaycastForInteractable()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, range))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if(interactable != null)
            {
                if(hit.distance <= interactable.MaxRange)
                {
                    if (interactable == currentTarget)
                    {
                        return;
                    }
                    else if(currentTarget != null)
                    {
                        currentTarget.OnEndInteraction();
                        currentTarget = interactable;
                        currentTarget.OnStartInteraction();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartInteraction();
                        return;
                    }
                }
                else
                {
                    if(currentTarget != null)
                    {
                        currentTarget.OnEndInteraction();
                        currentTarget = null;
                        return;
                    }
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnEndInteraction();
                    currentTarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndInteraction();
                currentTarget = null;
                return;
            }
        }
    }
}
