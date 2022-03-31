using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnergyShield : MonoBehaviour
{
    
    private Vector3 healthBasketMax = new Vector3(150, 150, 150);
    private Vector3 healthBasketMidl = new Vector3(100, 100, 100);
    private Vector3 healthBasketMin = new Vector3(50, 50, 50);



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }
    private void OnEnable()
    {
        EventManager.eventOnHealthUpdate += ChangeScaleElement;
    }
    void OnDisable()
    {
        EventManager.eventOnHealthUpdate -= ChangeScaleElement;
    }


    void Update()
    {
        if (Time.timeScale==1)
        {
            if (transform.position.x >= 12)
            {
                if (!(Input.GetAxis("Mouse X") < 0))
                {
                    transform.position += new Vector3(-(Input.GetAxis("Mouse X") * ScharedData.Sensitivity), 0f, 0f);
                }

            }
            else if (transform.position.x <= -12)
            {
                if (!(Input.GetAxis("Mouse X") > 0))
                {
                    transform.position += new Vector3(-(Input.GetAxis("Mouse X") * ScharedData.Sensitivity), 0f, 0f);
                }
            }
            else
            {
                transform.position += new Vector3(-(Input.GetAxis("Mouse X") * ScharedData.Sensitivity), 0f, 0f);
            }
        }
        
        
    }
    private void ChangeScaleElement()
    {
        if (ScharedData.Health==1)
        {
            gameObject.transform.localScale = healthBasketMin;
        }
        else if (ScharedData.Health == 2)
        {
            gameObject.transform.localScale = healthBasketMidl;
        }
        else if (ScharedData.Health == 3)
        {
            gameObject.transform.localScale = healthBasketMax;
        }
        
    }
    

}
