using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSchockwaveSpawnScript : MonoBehaviour
{
    private Vector3 SpawnPosition;
    private GameObject objCamera;
    private float delay = 8f;
    private float timeCurrent = 0.0f;

    public GameObject projectile;

    private GameObject projectileInstance;


    // Start is called before the first frame update
    void Start()
    {
        objCamera = (GameObject)GameObject.FindWithTag("Monster");



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

        
        SpawnPosition = objCamera.transform.forward  + objCamera.transform.position;
    
        GameObject projectileInstance = Instantiate(projectile, SpawnPosition, Quaternion.Euler(new Vector3(90,0, 0)));
        StartCoroutine(Waiter(projectileInstance));
        
    }

    IEnumerator Waiter(GameObject projectileInstance)
    {
        yield return new WaitForSeconds(0.5f);
        ParticleSystem ps = projectileInstance.GetComponent<ParticleSystem>();
        var psCollision = ps.collision;
        psCollision.enabled = true;
        psCollision.type = ParticleSystemCollisionType.World;
        psCollision.mode = ParticleSystemCollisionMode.Collision3D;
        psCollision.bounce = 0;
        psCollision.lifetimeLoss = 1;
        psCollision.maxKillSpeed = 0;
        psCollision.multiplyColliderForceByCollisionAngle = false;
        psCollision.sendCollisionMessages = true;
 
    }


}
