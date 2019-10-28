using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilesSpawnScript : MonoBehaviour
{
    private Vector3 SpawnPosition;
    private int DistanceToCamera = 1;
    private GameObject objCamera;
    private GameObject objMonstre;
    private float delay = 2f;
    private float timeCurrent = 0.0f;

    public GameObject projectile;

    private GameObject projectileInstance;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("Player");

        objMonstre = (GameObject)GameObject.FindWithTag("Monster");



    }

    // Update is called once per frame
    void Update()
    {

    }


    void instanciate()
    {
            SpawnPosition = objCamera.transform.forward * DistanceToCamera + objCamera.transform.position;
            projectileInstance = Instantiate(projectile, SpawnPosition, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileMoveScript>().speed = 10.0f;
            projectileInstance.GetComponent<ProjectileMoveScript>().accuracy = 100;
            projectileInstance.GetComponent<ProjectileMoveScript>().fireRate = 1;
            projectileInstance.transform.rotation = Quaternion.LookRotation(projectileInstance.transform.position - objCamera.transform.position);
            StartCoroutine(Waiter(projectileInstance));
            Destroy(projectileInstance,5);
    }

    IEnumerator Waiter(GameObject projectileInstance)
    {
        yield return new WaitForSeconds(0.5f);
        projectileInstance.GetComponent<SphereCollider>().enabled = true;
    }
}
