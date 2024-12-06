using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class timeToStart : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject secondCar;

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


        /*Elimina los errores de objetos no referenciados en escenas donde no son necesarios.
        * Por ejemplo, en la escena 1Car, no necesita referenciar el SecondCar. El hecho
        * de no hacerlo, hace saltar un error grave.*/
        if (SceneManager.GetActiveScene().name != "1Car") //Accede a los objetos referenciados si NO es la escena 1Car
        {
            secondCar.GetComponent<CarController>().enabled = false;
        }

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
            
            if (SceneManager.GetActiveScene().name != "1Car") //Accede a los objetos referenciados si NO es la escena 1Car
            {
                secondCar.GetComponent<CarController>().enabled = true;
            }
            
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


    

