using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject owlPrefab;
    public GameObject deerPrefab;

    private GameObject[] trees;
    //private Transform[] choosenTrees;
    public Transform treeObject;

    [SerializeField]
    private int maxOwls = 5;

    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        SpawnOwl(treeObject);
        //chooseTrees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnOwl(Transform tree)
    {
        int numSlices = Random.Range(1, 7);
        int slice = Random.Range(1, numSlices + 1);

        float treeRadius = tree.localScale.x;

        float angle = 360f / numSlices;

        Quaternion rotation = Quaternion.AngleAxis(slice * angle, Vector3.up);
        Vector3 direction = rotation * Vector3.forward;
        Vector3 position = tree.position + (direction * treeRadius);

        Instantiate(owlPrefab, position, rotation);
    }

    private void chooseTrees()
    {
        for (int i = 1; i <= maxOwls; i++)
        {
            SpawnOwl(trees[Random.Range(0, trees.Length)].transform);
        }
    }

    private int RandomNumber(int max)
    {
        return Random.Range(0, max);
    }
}
