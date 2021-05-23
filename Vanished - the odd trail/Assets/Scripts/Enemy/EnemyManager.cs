using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        //SpawnOwl(treeObject);
        //chooseTrees();
        SpawnOnAllTrees();
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

    public bool RandomPointInDonut(Vector3 center, float minRange, float maxRange, out Vector3 result, int areaMaks)
    {
        bool hitGround = false;
        center.y -= GroundDistance();
        do
        {
            Vector3 randomPoint = center + GetRandomInDonut(minRange, maxRange);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, areaMaks))
            {
                result = hit.position;
                hitGround = true;
                return true;
            }
        } while (hitGround == false);

        result = Vector3.zero;
        return false;
    }

    public static Vector3 GetRandomInDonut(float min, float max)
    {
        float rot = Random.Range(1f, 360f);
        Vector3 direction = Quaternion.AngleAxis(rot, Vector3.up) * Vector3.forward;
        Ray ray = new Ray(Vector3.zero, direction);

        return ray.GetPoint(Random.Range(min, max));
    }

    public float GroundDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            return hit.distance;
        }
        else
        {
            return 0;
        }

    }

}
