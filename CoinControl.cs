using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinControl : MonoBehaviour
{
    [SerializeField] float RotateSpeed;
    [SerializeField] public Text CoinCountText;
    [SerializeField] GameObject SoundPlayer, BuyyingCube, anaKup, AddedCoin, WinPanel;
    [SerializeField] AudioClip CoinCollect;
    private GameObject Keeper;
    public Text KeeperText;
    public TMP_Text AddedCoinText;
    public int CoinCount;
    public static int CollectCoinLevel, a;
    public Toplayici toplayici2;
    public int CubeCost;


    private void Awake()
    {
        Keeper = GameObject.Find("CoinCountNum");
        KeeperText = Keeper.GetComponent<Text>();
        CollectCoinLevel -= CollectCoinLevel;
        a -= a;
        SaveCoinCount();
        //PlayerPrefs.DeleteAll();
    }
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, RotateSpeed, 0f));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectCoinLevel += 1;
            a += 1;
            Debug.Log("CollectCoinLevel: " + CollectCoinLevel);
            SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CoinCollect);
            CoinCount = int.Parse(KeeperText.text);
            ++CoinCount;
            PlayerPrefs.SetInt("key", CoinCount);
            KeeperText.text = CoinCount.ToString();
            Destroy(this.gameObject);
        }
    }
    public void SaveCoinCount()
    {
        if (PlayerPrefs.HasKey("key"))
        {
            CoinCount = PlayerPrefs.GetInt("key");
            KeeperText.text = CoinCount.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("key", 0);
            KeeperText.text = PlayerPrefs.GetInt("key").ToString();
        }
    }
    public void EndOfLevelForCoins()
    {
        Debug.Log("Bu seviyede toplanan para: " + CollectCoinLevel);
        CoinCount = int.Parse(KeeperText.text);
        CollectCoinLevel -= a;
        CoinCount = CoinCount + CollectCoinLevel; // texte yazan + mevcut seviyede toplanan para
        PlayerPrefs.SetInt("key", CoinCount);
        KeeperText.text = CoinCount.ToString();
        Debug.Log("Merdiven sonucu: " + CollectCoinLevel);
    }
    //public void MultipleCoinOnStair()
    //{
    //    CoinCount = int.Parse(KeeperText.text);
    //    a = 0;
    //    CoinCount = CoinCount + CollectCoinLevel; // texte yazan + mevcut seviyede toplanan para
    //    KeeperText.text = CoinCount.ToString();
    //}

    public void BuyCube()
    {
        CoinCount = int.Parse(KeeperText.text);
        CubeCost = 150;
        if (CoinCount >= CubeCost)
        {
            CoinCount = CoinCount - CubeCost;
            PlayerPrefs.SetInt("key", CoinCount);
            KeeperText.text = CoinCount.ToString();
            AddCube();
        }
        else
        {
            Debug.Log("Bakiye yetersiz");
        }
    }
    public void AddCube()
    {
        anaKup = GameObject.Find("AnaKüp");
        BuyyingCube = GameObject.Find("ToplanacakCube (4)");
        GameObject AddedCube = Instantiate(BuyyingCube, anaKup.transform.position, Quaternion.identity);
        AddedCube.transform.parent = anaKup.transform;
    }

    public void AddCoinInEnd()
    {
        if(WinPanel.active == true)
        {
            AddedCoin = GameObject.Find("Collenct Coin In Level");
            Debug.Log("AddCoinInEnd is working");
            AddedCoinText = AddedCoin.GetComponent<TMP_Text>();
            AddedCoinText.text = CollectCoinLevel.ToString();
        }
    }



    //public void EndOfLevelForCoins()
    //{
    //    Debug.Log("Bu seviyede toplanan para: " + CollectCoinLevel);
    //    CoinCount = int.Parse(KeeperText.text);
    //    CollectCoinLevel = CoinCount + CollectCoinLevel;
    //    KeeperText.text = CoinCount.ToString();
    //}

    //private void OnTriggerEnter(Collider other) // yedek
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        SoundPlayer.GetComponent<AudioSource>().PlayOneShot(CoinCollect);
    //        CoinCount = int.Parse(CoinCountText.text);
    //        ++CoinCount;
    //        CoinCountText.text = CoinCount.ToString();
    //        Destroy(this.gameObject);
    //    }
    //}

}
