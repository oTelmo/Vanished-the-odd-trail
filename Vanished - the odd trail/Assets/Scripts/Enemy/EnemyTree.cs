using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTree : EnemyBase
{
    private bool treeAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreeAttackPlayer(float movementSpeed)
    {
        Vector3 upPosition = new Vector3(target.transform.position.x, transform.GetChild(0).position.y, target.transform.position.z);
        target.transform.position = Vector3.MoveTowards(target.transform.position, upPosition, Time.deltaTime * movementSpeed);

        if (!treeAttacked)
        {
            target.GetComponent<PlayerManager>().StartCameraShake(3f, 0.2f, 0.2f);
            treeAttacked = true;
        }
    }

}
