using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this is friendly");
                break;
            case "Finish":
                Debug.Log(" cool boi ");
                break;
            case "fuel":
                Debug.Log("oooo charge and feelin good");
                break;  
            default:
                reloadlevel();
                break;  

        }
    }
    void reloadlevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
}
