using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HostSingleton : MonoBehaviour
{
    private static HostSingleton instance;
    public  HostGameManager gameManager { get; private set; }

    public static HostSingleton Instance
    {
        get
        {
            if(instance != null) { return instance; }
            instance = FindObjectOfType<HostSingleton>();

            if (instance ==null)
            {
                Debug.LogError("No HostSingletion in the scene");
                return null;
            }
            return instance;
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
  
    public void CreateHost()
    {
        gameManager = new HostGameManager();

  
    }

    private void OnDestroy()
    {
        gameManager?.Dispose();
    }

}
