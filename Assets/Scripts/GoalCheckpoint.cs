using System;
using TMPro;
using UnityEngine;

public class GoalCheckpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject record;

    private bool recordSaved;

    private int goalDetector; //Es un contador. El coche pasa dos veces por meta, en la salida y en la llegada. Se guardará el tiempo la segunda vez.

    [SerializeField]
    private GameObject lapComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalDetector = 0;
        recordSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("detecta el coche");
            goalDetector++; //Suma uno al detector
        }

        //Pruebas con el detector a 1, pero tiene que ser 2 cuando funcione
        if (goalDetector == 2 && !recordSaved) //Si el coche pasa una segunda vez por la meta guarda el tiempo
        {
            recordSaved = true;
            record.GetComponent<TMP_Text>().text = timeToStart.gameTime.ToString("mm':'ss'.'ff");
            lapComplete.SetActive(true); //Aparece canvas Complete
        }
    }
}
