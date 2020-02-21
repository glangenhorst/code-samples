using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallBehavior : MonoBehaviour
{
    public Transform mParticleSystem;
    private MeshRenderer mMeshRenderer;

    void Awake() {
        mMeshRenderer = GetComponent<MeshRenderer>();
    }
    void OnTriggerStay(Collider other) {
        UpdateStream(GetHeight(other));
    }
    void OnTriggerExit(Collider other){
        UpdateStream(0);
    }
    private float GetHeight(Collider collider){
        return collider.transform.position.y + collider.bounds.size.y;
    }

    void UpdateStream(float newHeight){
        // Particle position (use large particles!!)
        Vector3 newPosition = new Vector3(transform.position.x, newHeight, transform.position.z);
        mParticleSystem.position = newPosition;
        //Cuts alpha here (connects to waterfall.shader
        newHeight /= transform.localScale.y;
        mMeshRenderer.material.SetFloat("_Cutoff", newHeight);
    }
}
