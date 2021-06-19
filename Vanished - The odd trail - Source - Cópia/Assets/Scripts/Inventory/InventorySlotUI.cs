using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public int id;
    public Image itemImage;
    public Button itemButton;
    private Animator anim;

    private void Start()
    {
       anim = GetComponent<Animator>();
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
    }
}
