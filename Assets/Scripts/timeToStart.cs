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
    private GameObject thirdCar;

    [SerializeField]
    private GameObject fourthCar;

    [SerializeField]
    private float countdownTime = 3f;

    [SerializeField]
    private GameObject chronometer; //GameObject cronometro del canvas

    [SerializeField]
    private GameObject chronometerSecondCar; //GameObject cronometro del canvas

    [SerializeField]
    private GameObject chronometerThirdCar; //GameObject cronometro del canvas

    [SerializeField]
    private GameObject chronometerFourthCar; //GameObject cronometro del canvas

    private float accumulatedTime; //Tiempo acumulado 

    public static TimeSpan gameTime; //Variable global para utilizarla en el script GoalCheckpoint
    public static TimeSpan gameTimeSecondCar; //Variable global para utilizarla en el script GoalCheckpoint
    public static TimeSpan gameTimeThirdCar; //Variable global para utilizarla en el script GoalCheckpoint
    public static TimeSpan gameTimeFourthCar; //Variable global para utilizarla en el script GoalCheckpoint

    [SerializeField]
    private GameObject goal;

    private bool raceStarted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<CarController>().enabled = false;

        raceStarted = false;

        /*Elimina los errores de objetos no referenciados en escenas donde no son necesarios.
        * Por ejemplo, en la escena 1Car, no necesita referenciar el SecondCar. El hecho
        * de no hacerlo, hace saltar un error grave.*/
        if (SceneManager.GetActiveScene().name != "1Car") //Accede a los objetos referenciados si NO es la escena 1Car
        {
            secondCar.GetComponent<CarController>().enabled = false;
        }

        if (SceneManager.GetActiveScene().name != "1Car" && SceneManager.GetActiveScene().name != "2Car") 
        {
            thirdCar.GetComponent<CarController>().enabled = false;
            fourthCar.GetComponent<CarController>().enabled = false;
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
            if(!raceStarted)
            {
                raceStarted = true;
                player.GetComponent<CarController>().enabled = true;

                if (SceneManager.GetActiveScene().name != "1Car") //Accede a los objetos referenciados si NO es la escena 1Car
                {
                    secondCar.GetComponent<CarController>().enabled = true;
                }

                if (SceneManager.GetActiveScene().name != "1Car" && SceneManager.GetActiveScene().name != "2Car")
                {
                    thirdCar.GetComponent<CarController>().enabled = true;
                    fourthCar.GetComponent<CarController>().enabled = true;
                }
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
            accumulatedTime = accumulatedTime + Time.deltaTime;
            gameTime = TimeSpan.FromSeconds(accumulatedTime);
            chronometer.GetComponent<TMP_Text>().text = gameTime.ToString("mm':'ss'.'ff");
           
        if (SceneManager.GetActiveScene().name != "1Car") //Condicion para que solo se utilice el crono del segundo en coche en la escena 2Car y 4car
            {
                gameTimeSecondCar = TimeSpan.FromSeconds(accumulatedTime);
                chronometerSecondCar.GetComponent<TMP_Text>().text = gameTimeSecondCar.ToString("mm':'ss'.'ff");
            }

        if (SceneManager.GetActiveScene().name != "1Car" && SceneManager.GetActiveScene().name != "2Car") //Crono para el tercer y cuarto coche en la escena 4Car
        {
            gameTimeThirdCar = TimeSpan.FromSeconds(accumulatedTime);
            chronometerThirdCar.GetComponent<TMP_Text>().text = gameTimeThirdCar.ToString("mm':'ss'.'ff");
            
            gameTimeFourthCar = TimeSpan.FromSeconds(accumulatedTime);
            chronometerFourthCar.GetComponent<TMP_Text>().text = gameTimeFourthCar.ToString("mm':'ss'.'ff");
        }

     yield return null;  
    }
}


    

