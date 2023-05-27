using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ToplanabilirKup : MonoBehaviour
{
    [SerializeField] public bool toplandiMi;
    [SerializeField] float index; // Yükseklik belirtiyor
    public Toplayici toplayici;
    [SerializeField] GameObject LosePanel,WinPanel,EndPanel;
    float nextTime;
    bool TimerOn = true;
    string mesaj;
    public PlayerController PlayerControllerVariable;
    public CameraControl CameraControllerVariable;
    [SerializeField] GameObject SoundPlayer;
    [SerializeField] AudioClip WinSound,LoseSound, CollisionSound, FallToPool;
    public CoinControl CoinController;
    public TMP_Text AddedCoinText;
    private GameObject AddedCoin;
    public static bool win;
    //private int X2B, X3B, X4B, X5B;
    // Start is called before the first frame update
    void Start()
    {
        toplandiMi = false;
        win = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Engel")) 
        {
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CollisionSound);
            toplayici.YukseklikAzalt();
            transform.parent = null; 
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            toplandiMi = true;
            if (toplayici.transform.childCount == 0)
            {
                SoundPlayer.GetComponent<AudioSource>().PlayOneShot(LoseSound);
                toplayici.movementStop();
                LosePanel.active = true;
            }

        }
        else if (other.gameObject.CompareTag("FinnishPoint"))
        {
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CollisionSound);
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            toplandiMi = true;
            if (toplayici.transform.childCount == 0)
            {
                win = true;
                CameraControllerVariable.FocusToplayici();
                CoinController.EndOfLevelForCoins();
                SoundPlayer.GetComponent<AudioSource>().PlayOneShot(WinSound);
                transform.parent = null;
                // GetComponent<BoxCollider>().enabled = false;
                //other.gameObject.GetComponent<BoxCollider>().enabled = false;
                toplandiMi = true;
                toplayici.movementStop();
                WinPanel.active = true;
                CoinController.AddCoinInEnd();
                //AddedCoin = GameObject.Find("Collenct Coin In Level");
                //AddedCoinText = AddedCoin.GetComponent<TMP_Text>();
                //AddedCoinText.text = CoinControl.CollectCoinLevel.ToString();


            }
        }
        else if (other.gameObject.CompareTag("FinnishLine"))
        {
            win = true;
            CoinController.EndOfLevelForCoins();
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(WinSound);
            transform.parent = null;
            // GetComponent<BoxCollider>().enabled = false;
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
            toplandiMi = true;
            toplayici.movementStop();
            WinPanel.active = true;
            AddedCoin = GameObject.Find("Collenct Coin In Level");
            AddedCoinText = AddedCoin.GetComponent<TMP_Text>();
            AddedCoinText.text = CoinControl.CollectCoinLevel.ToString();


        }
        else if (other.gameObject.CompareTag("FinnishPoint2x"))
        {
            // CoinController.CoinCount = int.Parse(CoinController.KeeperText.text);
            //int X2B = CoinControl.CollectCoinLevel * 2;
            CoinControl.CollectCoinLevel = CoinControl.CollectCoinLevel * 2;
            Debug.Log("2 X CollectCoinLevel: " + CoinControl.CollectCoinLevel);
            //CoinController.KeeperText.text = CoinController.CoinCount.ToString();
        }
        else if (other.gameObject.CompareTag("FinnishPoint3x"))
        {
            //CoinController.CoinCount = int.Parse(CoinController.KeeperText.text);
            //int X3B = CoinControl.CollectCoinLevel * 3 / 2;
            CoinControl.CollectCoinLevel = CoinControl.CollectCoinLevel * 3/2;
            Debug.Log("3 X CollectCoinLevel: " + CoinControl.CollectCoinLevel);
            //CoinController.KeeperText.text = CoinController.CoinCount.ToString();
        }
        else if (other.gameObject.CompareTag("FinnishPoint4x"))
        {
            //CoinController.CoinCount = int.Parse(CoinController.KeeperText.text);
            //X4B = CoinControl.CollectCoinLevel * 4 / 3;
            CoinControl.CollectCoinLevel = CoinControl.CollectCoinLevel * 4/3;
            Debug.Log("4 X CollectCoinLevel: " + CoinControl.CollectCoinLevel);
            //CoinController.KeeperText.text = CoinController.CoinCount.ToString();
        }
        else if (other.gameObject.CompareTag("FinnishPoint5x"))
        {
            //CoinController.CoinCount = int.Parse(CoinController.KeeperText.text);
            CoinControl.CollectCoinLevel = CoinControl.CollectCoinLevel * 5/4;
            Debug.Log("5 X CollectCoinLevel: " + CoinControl.CollectCoinLevel);
            //CoinController.KeeperText.text = CoinController.CoinCount.ToString();
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pool"))
        {
            TimerOn = true;
            //StartCoroutine(PoolTimer());
            //poolDestroy();
            //toplayici.transform.position = new Vector3(toplayici.transform.position.x, 0 , toplayici.transform.position.z);
            //toplayici.FallIntoPool();
            float A = Time.frameCount % 10;
            if ( A >= 8)
            {
                poolDestroy();
            }
        }
        else
        {
            //TimerOn = false;
            //StopCoroutine(PoolTimer());
            Time.timeScale = 1;
            //toplayici.transform.position = new Vector3(toplayici.transform.position.x, 1.5f , toplayici.transform.position.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pool"))
        {
            toplayici.onPlane = true;
        }
    }
    public bool GetToplandiMi()
    {
        return toplandiMi;
    }
    public void ToplandiYap()
    {
        toplandiMi = true;
    }
    public void ToplanmadiYap()
    {
        toplandiMi = false;
    }
    public void IndexAyarla(float index) // toplayýcýdaki yükseklik verilerini alýyor
    {
        this.index = index; // this.index = globaldeki index ; index = localdaki index
    }

    //IEnumerator PoolTimer()
    //{
    //    while (TimerOn)
    //    {
    //        poolDestroy();
    //        yield return new WaitForSeconds(0.1f);
    //        poolDestroy();
    //        yield return new WaitForSeconds(0.1f);
    //    }

    //}
    void poolDestroy()
    {
        SoundPlayer.GetComponent<AudioSource>().PlayOneShot(FallToPool);
        transform.parent = null;
        toplayici.YukseklikAzalt();
        //this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Destroy(this.gameObject);
        if (toplayici.transform.childCount == 0)
        {
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(LoseSound);
            toplayici.movementStop();
            LosePanel.active = true;
        }
    }
}
