using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System;
using System.Globalization;

public class SmartContractManager : MonoBehaviour
{


    
    public static Thirdweb.Contract contract = SDKManager.Instance.SDK.GetContract("0x5510FA6E3Ac73255b8f26D13b40d1C8807322E86", "[\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"addClass\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"nonpayable\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_Gamename\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"addGamename\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"nonpayable\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_score\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_date\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_time\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_data\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"addGameScore\",\r\n\t\t\"outputs\": [],\r\n\t\t\"stateMutability\": \"nonpayable\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_name\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_age\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"addInstructor\",\r\n\t\t\"outputs\": [],\r\n\t\t\"stateMutability\": \"nonpayable\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_name\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_age\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"_Instructor\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"addPlayer\",\r\n\t\t\"outputs\": [],\r\n\t\t\"stateMutability\": \"nonpayable\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"Classes\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"playercount\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"ClassPlayers\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"name\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"class\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"age\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"instructoraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"classid\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"GameIdentities\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gamename\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"GameID\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"NumberofScores\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"GameNamesbyID\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gamename\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"GameID\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"NumberofScores\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"GameScores\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"score\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"date\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"time\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"data\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_classid\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getClassPlayer\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getClassPlayerCount\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"y\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreCounts\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreData\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreDate\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreID\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreScore\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getGameScoreTime\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"uint256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"uint256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getInstructor\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"y\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"uint256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"uint256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"getPlayer\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"y\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_Gamename\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorcheckGamename\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreCounts\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreData\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreDate\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreID\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreScore\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"Gameidentity\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"_id\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstructorgetGameScoreTime\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"Instructors\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"name\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"Instructoraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"age\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"numberofclasses\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"numberofGamesCreated\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_classname\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"InstuctorcheckClass\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"Login\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"username\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"_Gamename\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"PlayercheckGamename\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"x\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t},\r\n\t{\r\n\t\t\"inputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"name\": \"Players\",\r\n\t\t\"outputs\": [\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"name\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"class\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"string\",\r\n\t\t\t\t\"name\": \"age\",\r\n\t\t\t\t\"type\": \"string\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"instructoraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"address\",\r\n\t\t\t\t\"name\": \"playeraddress\",\r\n\t\t\t\t\"type\": \"address\"\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"internalType\": \"int256\",\r\n\t\t\t\t\"name\": \"classid\",\r\n\t\t\t\t\"type\": \"int256\"\r\n\t\t\t}\r\n\t\t],\r\n\t\t\"stateMutability\": \"view\",\r\n\t\t\"type\": \"function\"\r\n\t}\r\n]");


    
   // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Score Functions
    public static async Task StoreScore(string Gamename,int Score, string date, string time, string scoredata)
    {
        var res = await contract.Write("addGameScore", Gamename, Score, date, time, scoredata);
    }

    public static async Task<int> GetTotalScoreCounts(string useraddress, string Gamename)
    {
        int res = await contract.Read<int>("getGameScoreCounts", useraddress, Gamename);

        return res;
    }

    public static async Task<int> GetScoreID(string useraddress, string Gamename, int id)
    {
        int res = await contract.Read<int>("getGameScoreID", useraddress, Gamename, id);
        return res;
    }

    public static async Task<int> GetScore(string useraddress, string Gamename, int id)
    {
         int res = await contract.Read<int>("getGameScoreScore", useraddress, Gamename, id);
        return res;
    }

    public static async Task<string> GetScoreDate(string useraddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("getGameScoreDate", useraddress, Gamename, id);
        return res;
    }

    public static async Task<string> GetScoreTime(string useraddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("getGameScoreTime", useraddress, Gamename, id);
        return res;
    }

    public static async Task<string> GetScoreData(string useraddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("getGameScoreData", useraddress, Gamename, id);
        return res;
    }

    public static async Task<int> TeacherGetTotalScoreCounts(string useraddress,string studentaddress, string Gamename)
    {
        int res = await contract.Read<int>("InstructorgetGameScoreCounts", useraddress, studentaddress, Gamename);

        return res;
    }

    public static async Task<int> TeacherGetScoreID(string useraddress, string studentaddress, string Gamename, int id)
    {
        int res = await contract.Read<int>("InstructorgetGameScoreID", useraddress, studentaddress, Gamename, id);
        return res;
    }

    public static async Task<int> TeacherGetScore(string useraddress, string studentaddress, string Gamename, int id)
    {
        int res = await contract.Read<int>("InstructorgetGameScoreScore", useraddress, studentaddress, Gamename, id);
        return res;
    }

    public static async Task<string> TeacherGetScoreDate(string useraddress, string studentaddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("InstructorgetGameScoreDate", useraddress, studentaddress, Gamename, id);
        return res;
    }

    public static async Task<string> TeacherGetScoreTime(string useraddress, string studentaddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("InstructorgetGameScoreTime", useraddress, studentaddress, Gamename, id);
        return res;
    }

    public static async Task<string> TeacherGetScoreData(string useraddress, string studentaddress, string Gamename, int id)
    {
        string res = await contract.Read<string>("InstructorgetGameScoreData", useraddress, studentaddress, Gamename, id);
        return res;
    }

    //Login Function
    public static async Task<string> Login(string useraddress)
    {
        var res = await contract.Read<string>("Login", useraddress);
        return res;
    }


    //Student Functions

    public static async Task StoreStudent(string newStudentName, string newStudentClass, string newStudentAge, string newStudentTeacherAddress)
    {
        var result = await contract.Write("addPlayer", newStudentName, newStudentClass, newStudentAge,newStudentTeacherAddress);
    }

    public static async Task<string> GetStudentName(string useraddress)
    {
        string res = await contract.Read<string>("getPlayer", useraddress, 1);
        return (res);
    }

    //Teacher Functions
    public static async Task StoreTeacher(string newTeacherName, string newTeacherAge)
    {
        var result = await contract.Write("addInstructor", newTeacherName, newTeacherAge);
    }

    public static async Task<string> GetTeacherName(string useraddress)
    {
        string ress = await contract.Read<string>("getInstructor", useraddress, 1);
        return(ress);
    }

    public static async Task<int> StoreClass(string useraddress, string newclass)
    {
        int ClassStatus = await contract.Read<int>("InstuctorcheckClass", useraddress, newclass);

        if (ClassStatus == 1)
        {
            var result = await contract.Write("addClass", newclass);
            Debug.Log("Registered Class");
            return 1;
        }
        else if (ClassStatus == 2)
        {
            Debug.Log("Already registered");
            return 2;
        }
        else
        {
            Debug.Log("Something is wrong");
            return 3;
        }
    }

    public static async Task<int> PureCheckClass(string useraddress, string newclassinput)
    {
        int ClassStatus = await contract.Read<int>("InstuctorcheckClass", useraddress, newclassinput);

        if (ClassStatus == 1)
        {
            Debug.Log("Registered Class");
            return 1;
        }
        else if (ClassStatus == 2)
        {
            Debug.Log("Already registered");
            return 2;
        }
        else
        {
            Debug.Log("Something is wrong");
            return 3;
        }
    }



    public static async Task<int> getClassCount(string useraddress, string newclassinput)
    {
        int ClassCount = await contract.Read<int>("getClassPlayerCount", useraddress, newclassinput);
        return ClassCount;
    }

    public static async Task<string> getStudentAddress(string useraddress, string newclassinput, int z)
    {
        string Studentaddress = await contract.Read<string>("getClassPlayer", useraddress, newclassinput, z);
        return Studentaddress;
    }

    public static async Task<string> TeachergetStudentName(string y)
    {
        string res = await contract.Read<string>("getPlayer", y, 1);
        Console.WriteLine(res);

        Debug.Log(res);

        return (res);

    }

    public static async Task<int> StoreGame(string useraddress, string newGame)
    {
        int Status = await contract.Read<int>("InstructorcheckGamename", useraddress, newGame);

        if (Status == 1)
        {
            var result = await contract.Write("addGamename", newGame);
            Debug.Log("Game sucessfully registered");
            return 1;
        }
        else if (Status == 2)
        {
            Debug.Log("Already registered");
            return 2;
        }
        else
        {
            Debug.Log("Something is wrong");
            return 3;
        }
    }

    public static async Task<int> TeacherCheckGame(string useraddress,string Gamename)
    {
        int Status = await contract.Read<int>("InstructorcheckGamename", useraddress, Gamename);

        if (Status == 1)
        {
            Debug.Log("Game sucessfully registered");
            return 1;
        }
        else if (Status == 2)
        {
            Debug.Log("Already registered");
            return 2;
        }
        else
        {
            Debug.Log("Something is wrong");
            return 3;
        }
    }

    public static async Task<int> StudentCheckGameName(string useraddress, string Gamename)
    {
        int GameNameStatus = await contract.Read<int>("PlayercheckGamename", useraddress, Gamename);
        return GameNameStatus;
    }



}
