using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_RaycastItemAligner : MonoBehaviour
{
    public float raycastDistance = 100f;
    public GameObject objectToSpawn;
    public float overlapTestBoxSize;
    public LayerMask spawnedObjectLayer;
    // Start is called before the first frame update
    void Start()
    {
        PositionRaycast();
    }
    void PositionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            if (numberOfCollidersFound == 0)
            {
                GameObject clone = Instantiate(objectToSpawn, hit.point, spawnRotation);
            }
            else
            {
                //print("hit");
            }


            

            
        }
    }
}
