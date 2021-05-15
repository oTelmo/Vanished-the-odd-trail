using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StruggleCheck : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float initialProgress = 0.5f;
    [SerializeField] private float decreaseRate = 0.8f;
    [SerializeField] private float increaseRate = 0.2f;

    [Header ("UI")]
    [SerializeField] private GameObject struggleSlider;
    [SerializeField] private GameObject struggleTextKey;
    private Slider slider; 

    private bool isStruggleCheckOn = false;
    private GameObject deer;
    private GameObject player;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        slider = struggleSlider.GetComponent<Slider>();

    }

    public void StartStruggleCheck(GameObject d)
    {
        if (!isStruggleCheckOn)
        {
            deer = d;
            //play audio
            Invoke("StruggleCheckStarter", 0.5f);
        }
        
    }

    private void StruggleCheckStarter()
    {
        slider.value = initialProgress;
        SetActiveGameUI(true);
        isStruggleCheckOn = true;
    }

    private void DoStruggleCheck()
    {
        slider.value -= decreaseRate * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            slider.value += increaseRate;
        }
        
        if(slider.value <= 0)
        {
            FinishStruggleCheck(false);

        }else if(slider.value >= 1)
        {
            FinishStruggleCheck(true);
        }
    }

    private void FinishStruggleCheck(bool result)
    {
        isStruggleCheckOn = false;
        SetActiveGameUI(false);

        if (result) //sucess
        {
            print("sucess");
            deer.GetComponent<EnemyDeer>().PlayerSucess();
            playerManager.PlayerDeerStopAttack();
            
        }
        else //failed
        {
            playerManager.PlayerDeath();
            print("failed");
        }
    }

    private void SetActiveGameUI(bool isActive)
    {
        struggleSlider.SetActive(isActive);
        struggleTextKey.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStruggleCheckOn)
        {
            DoStruggleCheck();
        }
    }
}
