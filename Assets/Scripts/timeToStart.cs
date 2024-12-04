using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class timeToStart : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float countdownTime = 3f;

    [SerializeField]
    private GameObject chronometer; //Prueba. GameObject cronometro del canvas

    private float accuaccumulatedTime; //Prueba. Tiempo acumulado 

    public static TimeSpan gameTime; //Variable global para utilizarla en el script GoalCheckpoint

    [SerializeField]
    private GameObject goal;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<CarController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
        }
        else
        {
            player.GetComponent<CarController>().enabled = true;
            StartChronometer(); //Empieza el cronometro cuando 
        }
    }


    public void StartChronometer() //Empieza el crono
    {
        StartCoroutine (UpdateChrono());
    }

    IEnumerator UpdateChrono() //Actualiza el crono con el que pasa
    {  
            accuaccumulatedTime = accuaccumulatedTime + Time.deltaTime;
            gameTime = TimeSpan.FromSeconds(accuaccumulatedTime);
            chronometer.GetComponent<TMP_Text>().text = gameTime.ToString("mm':'ss'.'ff");

        yield return null;  
    }

   

}


    

