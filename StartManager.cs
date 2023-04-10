using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb;
using System;

public class StartManager : MonoBehaviour
{
    public GameObject connected;
    public GameObject disconnected;
    public GameObject startBtn;
    public TMPro.TextMeshProUGUI addressTxt;

    public static string useraddress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ConnectWallet()
    {
        string address = await SDKManager.Instance.SDK.wallet.Connect(new WalletConnection()
            {
                provider = WalletProvider.MetaMask,
                chainId = 5 // Switch the wallet Goerli on connection
               
            });

        addressTxt.text = address;

        useraddress = address;

        connected.SetActive(true);

        disconnected.SetActive(false);

    }
    
    public async void StartGame()
    {

        

        //Task<string> Statuss = SmartContractManager.Login();
        //Statuss.Wait();
        
        string Status = await SmartContractManager.Login(useraddress);



        //String Status = SmartContractManager.AddressStatus;


        if (Status == "Student is registered")
        {
            Console.WriteLine("string: x Student is registered");
            SceneManager.LoadScene("StudentMain");
        } 
        
        else if (Status == "Teacher is registered")
        
        {
            SceneManager.LoadScene("TeacherMainPage");
            Console.WriteLine("Teacher is registered");
        }
        else if (Status == "Not registered")
        {
            SceneManager.LoadScene("Register");
            Console.WriteLine("Not registered");
        }
        else
        {
            Console.WriteLine("Confused");
        }
        
    }
    
}
