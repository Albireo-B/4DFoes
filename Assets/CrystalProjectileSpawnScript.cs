using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalProjectileSpawnScript : MonoBehaviour
{
    private Vector3 SpawnPosition;
    private int DistanceToCamera = 2;
    private GameObject objCamera;
    private GameObject[] objsPlayer;
    private float delay = 2f;
    private float timeCurrent = 0.0f;

    public GameObject projectile;

    private GameObject projectileInstance;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("Monster");
        objsPlayer = (GameObject[])GameObject.FindGameObjectsWithTag("Player");
        


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

        foreach (GameObject objPlayer in objsPlayer)
        {
            projectileInstance = Instantiate(projectile, SpawnPosition, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileMoveScript>().speed = 10.0f;
            projectileInstance.GetComponent<ProjectileMoveScript>().accuracy = 100;
            projectileInstance.GetComponent<ProjectileMoveScript>().fireRate = 1;
            projectileInstance.transform.LookAt(objPlayer.transform.position);
            StartCoroutine(Waiter(projectileInstance));
            Destroy(projectileInstance, 5);
        }
    }

    IEnumerator Waiter(GameObject projectileInstance)
    {
        yield return new WaitForSeconds(0.5f);
        projectileInstance.GetComponent<BoxCollider>().enabled = true;
    }


}
