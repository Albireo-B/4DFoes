using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOnTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Fonctionne pour les projectiles 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("QQCHOSE RENTRE DANS MON MONSTRE");
    }

 
}
