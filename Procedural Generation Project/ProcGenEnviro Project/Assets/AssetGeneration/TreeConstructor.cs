using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeConstructor : MonoBehaviour
{
    public int trunkSpawnVal;
    public int leavesSpawnVal;
    public int rockORtreeVal;
    public int rockSpawnVal;

    public int LmatSpawnVal;
    public int RmatSpawnVal;
    public int TmatSpawnVal;


    GameObject trunkToUse;
    GameObject leavesToUse;
    GameObject rockToUse;

    Material TmatToUse;
    Material LmatToUse;
    Material RmatToUse;


    public GameObject leaves1, leaves2, leaves3, leaves4, leaves5, leaves6, trunk1, trunk2, rock1, rock2;
    public GameObject trunkSpawnPoint, leavesSpawnPoint;
    public Material Lmat1, Lmat2, Lmat3, Lmat4, Lmat5, Lmat6, Lmat7, Lmat8, Lmat9, Lmat10, Lmat11, Lmat12, Lmat13, Lmat14;
    public Material Rmat1, Rmat2, Rmat3;
    public Material Tmat1, Tmat2, Tmat3,Tmat4,Tmat5,Tmat6;
    Quaternion rotationToUse;

    void Awake()
    {
        rotationToUse = trunkSpawnPoint.transform.rotation;
        MakeTree();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeTree()
    {
        rockORtreeVal = Random.Range(1, 10);
        trunkSpawnVal = Random.Range(1, 2);
        leavesSpawnVal = Random.Range(1, 6);
        LmatSpawnVal = Random.Range(1, 14); ;
        RmatSpawnVal = Random.Range(1, 3); ;
        TmatSpawnVal = Random.Range(1, 6); ;

        //Mats randomized
        if (TmatSpawnVal == 1)
        {
            TmatToUse = Tmat1;
        }
        else if (TmatSpawnVal == 2)
        {
            TmatToUse = Tmat2;
        }
        else if (TmatSpawnVal == 3)
        {
            TmatToUse = Tmat3;
        }
        else if (TmatSpawnVal == 4)
        {
            TmatToUse = Tmat4;
        }
        else if (TmatSpawnVal == 5)
        {
            TmatToUse = Tmat5;
        }
        else if (TmatSpawnVal == 6)
        {
            TmatToUse = Tmat6;
        }



        if (RmatSpawnVal == 1)
        {
            RmatToUse = Rmat1;
        }else if (RmatSpawnVal == 2)
        {
            RmatToUse = Rmat2;
        }
        else if (RmatSpawnVal == 3)
        {
            RmatToUse = Rmat3;
        }

        //AAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBAAAAAARGSFGSFDGSASFS

        if (LmatSpawnVal == 1)
        {
            LmatToUse = Lmat1;
        }
        else if (LmatSpawnVal == 2)
        {
            LmatToUse = Lmat2;
        }
        else if (LmatSpawnVal == 3)
        {
            LmatToUse = Lmat3;
        }
        else if (LmatSpawnVal == 4)
        {
            LmatToUse = Lmat4;
        }
        else if (LmatSpawnVal == 5)
        {
            LmatToUse = Lmat5;
        }
        else if (LmatSpawnVal == 6)
        {
            LmatToUse = Lmat6;
        }
        else if (LmatSpawnVal == 7)
        {
            LmatToUse = Lmat7;
        }
        else if (LmatSpawnVal == 8)
        {
            LmatToUse = Lmat8;
        }
        else if (LmatSpawnVal == 9)
        {
            LmatToUse = Lmat9;
        }
        else if (LmatSpawnVal == 10)
        {
            LmatToUse = Lmat10;
        }
        else if (LmatSpawnVal == 11)
        {
            LmatToUse = Lmat11;
        }
        else if (LmatSpawnVal == 12)
        {
            LmatToUse = Lmat12;
        }
        else if (LmatSpawnVal == 13)
        {
            LmatToUse = Lmat13;
        }
        else if (LmatSpawnVal == 14)
        {
            LmatToUse = Lmat14;
        }





        //end of mats
        if (trunkSpawnVal == 1)
        {
            trunkToUse = trunk1;
        }
        else if (trunkSpawnVal == 2)
        {
            trunkToUse = trunk2;
        }
        if (leavesSpawnVal == 1)
        {
            leavesToUse = leaves1;
        }
        else if (leavesSpawnVal == 2)
        {
            leavesToUse = leaves2;
        }
        else if (leavesSpawnVal == 3)
        {
            leavesToUse = leaves3;
        }
        else if (leavesSpawnVal == 4)
        {
            leavesToUse = leaves4;
        }
        else if (leavesSpawnVal == 5)
        {
            leavesToUse = leaves5;
        }
        else if (leavesSpawnVal == 6)
        {
            leavesToUse = leaves6;
        }
        if (rockORtreeVal >= 3){

            trunkToUse.GetComponent<Renderer>().material = TmatToUse;
            leavesToUse.GetComponent<Renderer>().material = LmatToUse;



            trunkSpawnPoint.transform.position = transform.position + new Vector3(0, -20, 0);
            
            Instantiate(trunkToUse, trunkSpawnPoint.transform.position, rotationToUse);
            Instantiate(leavesToUse, leavesSpawnPoint.transform.position, rotationToUse);
        } else if (rockORtreeVal < 3)
        {


            rockSpawnVal = Random.Range(1, 3);
            if (rockSpawnVal == 1)
            {
                rockToUse = rock1;
            }
            else if (rockSpawnVal == 2)
            {
                rockToUse = rock2;
            }
            rockToUse.GetComponent<Renderer>().material = RmatToUse;
            Instantiate(rockToUse, trunkSpawnPoint.transform.position, rotationToUse);
        }
        

    }
}
