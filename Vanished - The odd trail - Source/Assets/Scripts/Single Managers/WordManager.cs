using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header("World")]
    public GameObject oldLadyFirePit;
    public GameObject oldLadyTrees;
    public GameObject treeCollider;
    public GameObject[] bossFirePits;
    public GameObject mushroomTrail2;
    public GameObject doorCollider;
   
    [Header("Enemies")]
    //public GameObject firstDeer;
    public GameObject boss;

    [Header("Dummy enemies")]
    public GameObject dummyBoss;

    // Start is called before the first frame update
    void Start()
    {
        oldLadyFirePit.transform.GetChild(0).gameObject.SetActive(false);
        boss.SetActive(false);
        mushroomTrail2.SetActive(false);
        doorCollider.SetActive(false);
        dummyBoss.SetActive(false);
        //treeCollider.SetActive(false);
    }

    public void LockerOpened()
    {
        treeCollider.SetActive(true);
        mushroomTrail2.SetActive(true);
        doorCollider.SetActive(true);
    }

    public void LeftWatchtower()
    {
        dummyBoss.SetActive(true);
    }

    public void StartEndGame()
    {
        oldLadyFirePit.GetComponent<OldLadyFirePitInteraction>().StartOldLadyFirePit();
        treeCollider.GetComponent<FirstTreesSpawn>().DisableTrees();

        SetChildren(oldLadyTrees.transform, true);
    }

    private void SetChildren(Transform transform, bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

    /*public void SpawnFirstDeer()
    {
        firstDeer.gameObject.SetActive(true);
    }*/

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
        //MissionFileInteraction.OnOpenFile += SpawnFirstDeer;
        LockerInteraction.OnOpenLocker += LockerOpened;
        BossItemInteraction.OnItemPick += StartEndGame;
        DoorCollider.OnLeaveWatchtower += LeftWatchtower;

    }

    private void OnDisable()
    {
        //MissionFileInteraction.OnOpenFile -= SpawnFirstDeer;
        LockerInteraction.OnOpenLocker -= LockerOpened;
        BossItemInteraction.OnItemPick -= StartEndGame;
        DoorCollider.OnLeaveWatchtower -= LeftWatchtower;
    }

}
