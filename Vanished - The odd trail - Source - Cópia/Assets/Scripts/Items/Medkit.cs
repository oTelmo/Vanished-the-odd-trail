using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medkit : MonoBehaviour
{
    [Header("UI")]
    public PlayerManager playerManager;
    public GameObject sliderObject;
    private Slider slider;

    [Header("Stats")]
    [Range(0, 1)]
    [SerializeField] private float initialProgress = 0;
    [SerializeField] private float increaseRate = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();
        slider.value = initialProgress;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && playerManager.isInventoryOpen == false)
        {
            sliderObject.SetActive(true);
            slider.value += increaseRate * Time.deltaTime;
        }
        else
        {
            slider.value = 0;
            sliderObject.SetActive(false);
            
        }

        if(slider.value >= 1)
        {
            playerManager.PlayerRestoreHealth(1);
        }
    }

}
