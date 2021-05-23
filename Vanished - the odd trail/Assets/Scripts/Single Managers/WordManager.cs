using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header("World")]
    public GameObject oldLadyFirePit;
    public GameObject treeCollider;
    public GameObject[] bossFirePits;
    [Header("Enemies")]
    public GameObject firstDeer;
    public GameObject boss;
    
    // Start is called before the first frame update
    void Start()
    {
        oldLadyFirePit.transform.GetChild(0).gameObject.SetActive(false);
        firstDeer.SetActive(false);
        boss.SetActive(false);
    }

    public void StartTrees()
    {
        treeCollider.SetActive(true);
    }

    public void StartEndGame()
    {
        oldLadyFirePit.GetComponent<OldLadyFirePitInteraction>().StartOldLadyFirePit();
    }

    public void SpawnFirstDeer()
    {
        firstDeer.gameObject.SetActive(true);
    }

    public void StartBossFight()
    {
        boss.SetActive(true);
        foreach(GameObject firepit in bossFirePits)
        {
            firepit.GetComponent<FirePitInteraction>().fireOn = true;
        }
    }

    private void OnEnable()
    {
        MissionFileInteraction.OnOpenFile += SpawnFirstDeer;
    }

    private void OnDisable()
    {
        MissionFileInteraction.OnOpenFile -= SpawnFirstDeer;
    }

}
