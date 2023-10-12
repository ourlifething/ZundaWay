using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Level1");
    }

}
