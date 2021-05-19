using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemies Prefabs")]
    public GameObject owlPrefab;
    public GameObject deerPrefab;

    private GameObject[] trees;
    //private Transform[] choosenTrees;
    public Transform treeObject;

    [Header("Enemies Spawn Stats")]
    [SerializeField]
    private int numberOwls = 5;
    /*[SerializeField]
    private int numberDeers = 3;
    [SerializeField]
    private int numberTrees = 3;

    private int currentOwls;
    private int currentDeers;
    private int currentTrees;*/


    [Header("Enemies Areas")]
    public GameObject DeerOwlZone;
    public GameObject TreeZone;

    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        //SpawnOwl(treeObject);
        //chooseTrees();
        SpawnOnAllTrees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnOwl(Transform tree)
    {
        int numSlices = Random.Range(1, 7);
        int slice = Random.Range(1, numSlices + 1);
        Vector3 heightPosition = new Vector3(0, tree.position.y/4, 0);

        float treeRadius = tree.localScale.x+1;

        float angle = 360f / numSlices;

        Quaternion rotation = Quaternion.AngleAxis(slice * angle, Vector3.up);
        Vector3 direction = rotation * Vector3.forward;
        Vector3 position = (tree.position + heightPosition) + (direction * treeRadius);

        Instantiate(owlPrefab, position, rotation);
    }

    private void chooseTrees()
    {
        for (int i = 1; i <= numberOwls; i++)
        {
            SpawnOwl(trees[Random.Range(0, trees.Length)].transform);
            
        }
    }

    private void SpawnOnAllTrees()
    {
        for (int i = 0; i < trees.Length; i++)
        {
            SpawnOwl(trees[i].transform);
            //currentOwls++;
        }
    }

    private int RandomNumber(int max)
    {
        return Random.Range(0, max);
    }



}
