using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OneCarScene(){
        SceneManager.LoadScene("1Car");
    }

    public void TwoCarScene(){
        SceneManager.LoadScene("2Car");
    }

    public void FourCarScene(){
        SceneManager.LoadScene("4Car");
    }

      public void Exit()
    {
        Application.Quit();
    }
}
