using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTextScript : MonoBehaviour
{

    static CoinTextScript DefineCoinNum = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if(DefineCoinNum != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DefineCoinNum = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
