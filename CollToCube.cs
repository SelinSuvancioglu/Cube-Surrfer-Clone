using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollToCube : Toplayici
{
   [SerializeField] GameObject ToplayiciCube;
   // float yukseklik2;
    private void Start()
    {
    //  yukseklik2 = ToplayiciCube.GetComponent<Toplayici>().yukseklik;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.gameObject.GetComponent<ToplanabilirKup>().GetToplandiMi() == false)
        {
            yukseklik += 1;
            other.gameObject.GetComponent<ToplanabilirKup>().ToplandiYap();
            other.gameObject.GetComponent<ToplanabilirKup>().IndexAyarla(yukseklik);
            other.gameObject.transform.parent = this.transform; // toplanabilir küp anaKübün altýnda toplanacak
            other.gameObject.AddComponent<Toplayici>();
            other.gameObject.AddComponent<CollToCube>();
        }
    }
}
