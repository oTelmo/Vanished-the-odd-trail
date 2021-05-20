using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public GameObject oldLadyFirePit;
    

    // Start is called before the first frame update
    void Start()
    {
        oldLadyFirePit.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEndGame()
    {
        oldLadyFirePit.transform.GetChild(0).gameObject.SetActive(true);
    }
}
