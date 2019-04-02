using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TutorMeNow
{
    public class ChatHub : Hub
    {
        static protected ArrayList pArray = new ArrayList();


        static public void AddMessage(string sDealer,
                              string sUser, string sMsg)
        {
            string sAddText = sDealer + "~" + sUser + "~" + sMsg;
            pArray.Add(sAddText);

            if (pArray.Count > 200)
            {
                pArray.RemoveRange(0, 10);
            }
        }

        static public string GetAllMessages(string sDealer)
        {
            string sResponse = "";

            for (int i = 0; i < pArray.Count; i++)
            {
                sResponse = sResponse +
                    FormatChat(pArray[i].ToString(), sDealer);
            }

            return (sResponse);
        }

        static private string FormatChat(string sLine, string sDealer)
        {
            int iFirst = sLine.IndexOf("~");
            int iLast = sLine.LastIndexOf("~");

            string sDeal = sLine.Substring(0, iFirst);
            if (sDeal != sDealer)
                return ("");

            string sUser = sLine.Substring(iFirst + 1, iLast - (iFirst + 1));

            string sMsg = sLine.Substring(iLast + 1);

            string sRet = "" + sUser + ": " + sMsg + "";

            return (sRet);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}