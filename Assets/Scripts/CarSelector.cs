using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraSelection;

    [SerializeField]
    private GameObject cameraPositions;

    private int numberPosition;

    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;

    [SerializeField]
    private float changeVel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftArrow.SetActive(false);

        numberPosition = 0;

        cameraSelection.gameObject.transform.position = cameraPositions.transform.GetChild(numberPosition).position;
    }

    public void ChangeCamPosition(int n)
    {
        numberPosition += n;

        if (numberPosition == 0)
        {
            leftArrow.SetActive(false);
        }
        else if(numberPosition == cameraPositions.transform.childCount-1)
        {
            rightArrow.SetActive(false);
        }
        else 
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
    }

    public void SelectCar()
    {
        PlayerPrefs.SetInt("CARSELECTED", numberPosition);

        this.gameObject.GetComponent<SceneManagement>().ChangeScene("1Car");
    }

    private void Update()
    {
        cameraSelection.gameObject.transform.position = Vector3.MoveTowards(cameraSelection.gameObject.transform.position, cameraPositions.transform.GetChild(numberPosition).gameObject.transform.position, changeVel * Time.deltaTime);
    }
}
