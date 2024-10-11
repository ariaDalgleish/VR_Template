using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class FireBulletOnActivate : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint; // where bullet spawns
    public float fireSpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>(); 
        grabbable.activated.AddListener(FireBullet); // event
    }

  
    public void FireBullet(ActivateEventArgs args) // parameter 
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}
