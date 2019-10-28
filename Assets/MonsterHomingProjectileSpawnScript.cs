using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHomingProjectileSpawnScript : MonoBehaviour
{
    private Vector3 SpawnPosition;
    private int DistanceToCamera = 2;
    private GameObject objCamera;
    private GameObject objPlayer;

    private float delay = 5f;
    private float timeCurrent = 0.0f;
    public GameObject projectile;
    private GameObject projectileInstance;

    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("Monster");
        objPlayer = (GameObject)GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCurrent + delay < Time.fixedTime)
        {
            instanciate();
            timeCurrent = Time.fixedTime;
        }
    }


    void instanciate()
    {

        SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;

            projectileInstance = Instantiate(projectile, SpawnPosition, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileMoveScript>().speed = 30.0f;
            projectileInstance.GetComponent<ProjectileMoveScript>().accuracy = 100;
            projectileInstance.GetComponent<ProjectileMoveScript>().fireRate = 1;
            projectileInstance.GetComponent<ProjectileMoveScript>().isHoming = true;
            projectileInstance.GetComponent<ProjectileMoveScript>().homingTarget = objPlayer.transform;
            projectileInstance.transform.LookAt(objPlayer.transform.position);
            StartCoroutine(Waiter(projectileInstance));
        
    }

    IEnumerator Waiter(GameObject projectileInstance)
    {
        yield return new WaitForSeconds(0.5f);
        projectileInstance.GetComponent<SphereCollider>().enabled = true;
    }


}
