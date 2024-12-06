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

    [SerializeField]
    private GameObject player;

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
        if (goalDetector == 2 && !recordSaved && player.gameObject.GetComponent<Checkpoints>().midleCheckpointPassed && player.gameObject.GetComponent<Checkpoints>().finalCheckpointPassed) 
            //Si el coche pasa una segunda vez por la meta y ha pasado por el checkpoint del medio (aprox) y el último, guarda el tiempo y acaba la carrera
        {
            recordSaved = true;
            record.GetComponent<TMP_Text>().text = timeToStart.gameTime.ToString("mm':'ss'.'ff");
            lapComplete.SetActive(true); //Aparece canvas Complete
        }
    }
}
