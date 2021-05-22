using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public GameObject oldLadyFirePit;
    public GameObject treeCollider;
    public GameObject firstDeer;
    private PlayerManager playerManager;
    
    // Start is called before the first frame update
    void Start()
    {
        oldLadyFirePit.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void SpawnFirstDeer()
    {
        firstDeer.gameObject.SetActive(true);
    }

    public void StartTrees()
    {
        treeCollider.SetActive(true);
    }

    public void StartEndGame()
    {
        oldLadyFirePit.GetComponent<OldLadyFirePitInteraction>().StartOldLadyFirePit();
    }

    
}
