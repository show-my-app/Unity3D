﻿using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBAlertIOS : MonoBehaviour
    {
        //-------------------------------------------------------------------------------------------------------------
        const string K_OK = "OK";
        //-------------------------------------------------------------------------------------------------------------
        public string Title;
        public string Message;
        public string Ok;
        public BTBAlertOnCompleteBlock CompleteBlock;
        //-------------------------------------------------------------------------------------------------------------
        public static BTBAlertIOS Create(string sTitle, string sMessage)
        {
            return Create(sTitle, sMessage, K_OK, null);
        }
        //-------------------------------------------------------------------------------------------------------------
        public static BTBAlertIOS Create(string sTitle, string sMessage, string sOK, BTBAlertOnCompleteBlock sCompleteBlock)
        {
            BTBAlertIOS tDialog = new GameObject("BTBAlertIOS_GameObject").AddComponent<BTBAlertIOS>();
            tDialog.Title = sTitle;
            tDialog.Message = sMessage;
            tDialog.Ok = sOK;
            tDialog.CompleteBlock = sCompleteBlock;
            tDialog.Initialization();
            return tDialog;
        }
        //-------------------------------------------------------------------------------------------------------------
        public void Exec()
        {
        }
        //-------------------------------------------------------------------------------------------------------------
        public void Initialization()
        {
            BTBNativeDialogIOS.ShowAlert(Title, Message, Ok);
        }
        //-------------------------------------------------------------------------------------------------------------
        public void OnAlertCallback(string sButtonIndex) // call from .mm! Don't change the name
        {
            if (CompleteBlock != null)
            {
                CompleteBlock(BTBMessageState.OK);
            }
            Destroy(gameObject);
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================