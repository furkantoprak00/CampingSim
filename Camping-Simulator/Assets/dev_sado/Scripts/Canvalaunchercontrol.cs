using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvalaunchercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject go;
    int �d = 1;
    string isim ="Host:";
    bool isimBulduMu = true;
    public void Spawner()
    {
        while (isimBulduMu)
        {
            go = GameObject.Find(isim + �d);
            if (go!=null)
            {
                go.GetComponent<CanvaLauncher>().Spawn();

                isimBulduMu = false;
            }
            else
            {
                �d++;
            }
        }
    }
}
