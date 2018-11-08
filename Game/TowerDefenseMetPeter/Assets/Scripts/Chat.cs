///////////////////////////////////////
///THIS SCRIPT IS WORK IN PROGRESS!////
///////////////////////////////////////

///////////////////////////////////////////////////
////This script is for the local chat function.////
///////////////////////////////////////////////////
////In the case that multiplayer is active this////
////Should be activated, Cheats can be executed////
////Via this chat window, the current work pro-////
////cess for it is 1: Look if the chatbox exis-////
////ts, if not; quit, else continue. Then wait ////
////for text change, and then update the text. ////
////Boom, easy. Hope you like it! - Sjors K.   ////
///////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chat : MonoBehaviour {
    string NickName;
    Text ChatBoxText;

    private void Awake()
    {
        ChatBoxText = GameObject.Find("ChatBox").GetComponent<Text>();
        NickName = PlayerPrefs.GetString("UserName", "Player");
    }

    public void SendMSG(string Message)
    {
        string[] SplitCommand = Message.Split(' ');
        //if (SplitCommand[1].ToLower() == "/nick")
        if (Message.Contains("/nick"))
        {
            PlayerPrefs.SetString("UserName", SplitCommand[1]);
            ChatBoxText.text = "<b>" + NickName + "</b> changed their name to: <b>" + SplitCommand[1] + "</b>.\n" + ChatBoxText.text;
            NickName = PlayerPrefs.GetString("UserName", "Player");
        }
        else
        {
            ChatBoxText.text = "[<b>" + NickName + "</b>]: " + Message + ".\n" + ChatBoxText.text;
        }
    }
}
