using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject scoutRig;
    public Animator scoutSlaying;

    private void Start()
    {
        GetRagdollComponents();
        RagdollDeactivate();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            RagdollActivate();
        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidBodies;

    void GetRagdollComponents()
    {
        ragDollColliders = scoutRig.GetComponentsInChildren<Collider>();
        limbsRigidBodies = scoutRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollDeactivate()
    {
        scoutSlaying.enabled = true;

        // turn all colliders off
        foreach (Collider col in ragDollColliders) 
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = true;
        }
                
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void RagdollActivate()
    {
        scoutSlaying.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    //private NavMeshAgent agent;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    SetupRagdoll();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void SetupRagdoll()
    //{
    //    foreach (var item in GetComponentsInChildren<Rigidbody>())
    //    {
    //        item.isKinematic = true;
    //    }
    //}

    //public void Dead(Vector3 hitPosition)
    //{
    //    foreach (var item in GetComponentsInChildren<Rigidbody>()) 
    //    {
    //        item.isKinematic = false;
    //    }

    //    foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
    //    {
    //        Rigidbody rb = item.GetComponent<Rigidbody>();
    //    }
    //}
}
