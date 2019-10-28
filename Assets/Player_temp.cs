using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_temp : MonoBehaviour
{
    [SerializeField]
    public Stat hp;
    [SerializeField]
    public Stat energy;

    private void Awake()
    {
        hp.Initialize();
        energy.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        EnergyOverTime(20);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                FireBall(5);
            }
        }
    }

    //La valeur doit être comprise entre 0 et 1
    public void EnergyOverTime(float energyAmountPerSecond)
    {
        StartCoroutine(EnergyOverTimeTimeCoroutine(energyAmountPerSecond, energy));
    }

    IEnumerator EnergyOverTimeTimeCoroutine(float energyAmountPerSecond, Stat energy)
    {
        while (true)
        {
            energy.setVal(energy.getVal() + energyAmountPerSecond/100);
            yield return new WaitForSeconds(0.01F);
        }
    }

    public void FireBall(float cout)
    {
        if (energy.getVal() >= cout)
        {
            energy.setVal(energy.getVal() - cout);
        } 
    }
}
