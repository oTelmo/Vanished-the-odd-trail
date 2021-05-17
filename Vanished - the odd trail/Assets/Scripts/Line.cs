using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject firepit;
    public GameObject boss;
    public Material material;

    private LineRenderer line;

    // Use this for initialization
    void Start()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.positionCount = 2;
        line.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        if (firepit != null && boss != null)
        {
            line.SetPosition(0, firepit.transform.position);
            line.SetPosition(1, boss.transform.position);
        }
    }
}
