using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Checkpoints : MonoBehaviour
{
    private GameObject lastCheckpoint;

    [SerializeField]
    private GameObject warningMessage;

    public bool midleCheckpointPassed;
    public bool finalCheckpointPassed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warningMessage.SetActive(false);

        midleCheckpointPassed = false;
        finalCheckpointPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && this.gameObject.tag == "Player")
        {
            if (lastCheckpoint != null)
            {
                this.gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(-2.0f, 0.0f, 0.0f);
                this.gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                CancelInvoke("ShowWarningMessage");
                warningMessage.SetActive(false);
                this.GetComponent<CarController>().enabled = true;
                this.GetComponent<CarController>().m_Rigidbody.linearVelocity = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.M) && this.gameObject.tag == "SecondCar")
        {
            if (lastCheckpoint != null)
            {
                this.gameObject.transform.position = lastCheckpoint.transform.GetChild(0).position + new Vector3(2.0f, 0.0f, 0.0f);
                this.gameObject.transform.rotation = lastCheckpoint.transform.GetChild(0).rotation;
                CancelInvoke("ShowWarningMessage");
                warningMessage.SetActive(false);
                this.GetComponent<CarController>().enabled = true;
                this.GetComponent<CarController>().m_Rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            if(other.gameObject.name == "Checkpoint1")
            {
                midleCheckpointPassed = true;
            }
            if (other.gameObject.name == "Checkpoint2")
            {
                finalCheckpointPassed = true;
            }

            lastCheckpoint = other.gameObject;
        }
        if (other.gameObject.tag == "Terrain")
        {
            Invoke("ShowWarningMessage", 1.5f);

            StopCar();
        }
    }
    

    public void ShowWarningMessage()
    {
        warningMessage.SetActive(true);
    }

    public void StopCar()
    {
        this.GetComponent<CarController>().enabled = false;
    }
}
