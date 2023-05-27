using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public ToplanabilirKup WinController;
    void Update()
    {
        if(ToplanabilirKup.win == true) // if player win level, he start to dance.
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Win");
        }
    }
}
