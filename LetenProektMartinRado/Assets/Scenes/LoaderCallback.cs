using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if(isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }

}
