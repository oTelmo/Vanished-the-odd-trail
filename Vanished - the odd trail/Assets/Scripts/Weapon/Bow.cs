using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [System.Serializable]
    public class BowSettings
    {
        [Header("Arrow Settings")]
        public float arrowCount;
        public Rigidbody arrowPrefab;
        public Transform arrowPosition;
        public Transform arrowEquipParent;
        public float arrowForce = 3;

        [Header("Bow Equip & Unequip Settings")]
        public Transform equipPosition;
        public Transform unequipPosition;

        public Transform unequipParent;
        public Transform equipParent;

        [Header("Bow String Settings")]
        public Transform bowString;
        public Transform stringInitialPosition;
        public Transform stringHandPullPosition;
        public Transform stringInitialParent;
    }
    [SerializeField]
    public BowSettings bowSettings;

    [Header("Crosshair Settings")]
    public GameObject crossHairPrefab;
    GameObject currentCrossHair;

    Rigidbody currentArrow;

    /*bool canPullString = false;
    bool canFireArrow = false;*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickArrow()
    {
        bowSettings.arrowPosition.gameObject.SetActive(true);
    }

    public void DisableArrow()
    {
        bowSettings.arrowPosition.gameObject.SetActive(false);
    }

    public void PullString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringHandPullPosition.position;
        bowSettings.bowString.transform.parent = bowSettings.stringHandPullPosition;
    }

    public void ReleaseString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringInitialPosition.position;
        bowSettings.bowString.transform.parent = bowSettings.stringInitialParent;
    }

    public void EquipBow()
    {
        this.transform.position = bowSettings.equipPosition.position;
        this.transform.rotation = bowSettings.equipPosition.rotation;
        this.transform.parent = bowSettings.equipParent;
    }

    public void UnequipBow()
    {
        this.transform.position = bowSettings.unequipPosition.position;
        this.transform.rotation = bowSettings.unequipPosition.rotation;
        this.transform.parent = bowSettings.unequipParent;
    }

    /*public void ShowCrossHair(Vector3 crossHairPos)
    {
        if (!currentCrossHair)
            currentCrossHair = Instantiate(crossHairPrefab) as GameObject;

        currentCrossHair.transform.position = crossHairPos;
        currentCrossHair.transform.LookAt(Camera.main.transform);
    }

    public void RemoveCrossHair()
    {
        if (currentCrossHair)
            Destroy(currentCrossHair);
    }*/

    public void Fire(Vector3 hitPoint)
    {
        if (bowSettings.arrowCount < 1)
        {
            return;
        }
        Vector3 dir = hitPoint - bowSettings.arrowPosition.position;
        currentArrow = Instantiate(bowSettings.arrowPrefab, bowSettings.arrowPosition.position, bowSettings.arrowPosition.rotation) as Rigidbody;
        currentArrow.AddForce(dir * bowSettings.arrowForce, ForceMode.Force);

        bowSettings.arrowCount -= 1;
        
    }
}
