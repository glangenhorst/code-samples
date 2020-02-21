using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_ItemAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numItemsToSpawn = 10;

    public float itemXspread = 10;
    public float itemYspread = 0;
    public float itemZspread = 10;
    public int seedVal;

    // Start is called before the first frame update
    void Start()
    {

        seedVal = GameObject.Find("MapGeneratorObj").GetComponent<MapGenerator>().seed;
        //print(seedVal);
        Random.InitState(seedVal);

        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItems();
        }

    }

    void SpreadItems()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXspread, itemXspread), Random.Range(-itemYspread, itemYspread), Random.Range(-itemZspread, itemZspread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPosition, Quaternion.identity);
    }


}