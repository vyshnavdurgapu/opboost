using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    [SerializeField]float delay = 1.5f;
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this is friendly");
                break;
            case "Finish":
                landedsequence();
                break; 
            default:
                startcrashedsequence();
                break;  

        }
    }
    void landedsequence()
    {
        GetComponent<movement>().enabled = false;
        Invoke("loadnextlevel",delay);
    }
    void startcrashedsequence()
    {
        GetComponent<movement>().enabled = false;
        Invoke("reloadlevel",delay);
    }
    void reloadlevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
    void loadnextlevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        int nextlevelindex = currentsceneindex + 1;
        if (nextlevelindex == SceneManager.sceneCountInBuildSettings)
        {
            nextlevelindex = 0;
        }
        SceneManager.LoadScene(nextlevelindex);
    }
}
