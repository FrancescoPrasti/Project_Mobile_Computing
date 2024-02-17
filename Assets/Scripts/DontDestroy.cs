using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //public  SceneTransition transition;
    public GameObject canvasG;

    //public static Vector3[] posPorte = new Vector3[2]; 
    public static Vector3 posPorta;

    private void Awake()
    {


        
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Porta");


        /*if (transition.sceneToLoad != "Stanza1")
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvasG);*/

        /*for(int i=0; i<2;i++)
         {
             DontDestroyOnLoad(obj[i]);
             //posPorte[i]= obj[i].transform.position;
         }*/



        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvasG);
        posPorta=this.gameObject.transform.position;






    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
