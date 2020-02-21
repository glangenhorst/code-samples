using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMatAssignerScript : MonoBehaviour
{
    public Material transferMat;
    GameObject parentObject;

    void Awake()
    {
        parentObject = transform.parent.gameObject;
        transferMat = parentObject.GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = transferMat;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
