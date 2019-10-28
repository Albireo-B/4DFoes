using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    private Image bar;

    private float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        bar.fillAmount = fillAmount;
    }

    //La valeur doit être comprise entre 0 et 1
    public void setVal(float amount)
    {
        fillAmount = amount;
    }
}
