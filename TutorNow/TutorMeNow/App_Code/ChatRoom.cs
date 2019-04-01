using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorMeNow.App_Code
{
    //public class ChatRoom : IDisposable
    //{
    //    public List<message /> messages = null;
    //    public string RoomID;
    //    private Dictionary<string, chatuser /> RoomUsers;
    //    private int userChatRoomSessionTimeout;

    //    public void Dispose()
    //    {
    //        this.messages.Clear();
    //        this.RoomID = "";
    //        foreach(object key in RoomUsers.Keys)
    //        {
    //            this.RoomUsers[key.ToString()].Dispose ();
    //        }
    //    }

    //    public ChatRoom(string roomID)
    //    {
    //        this.messages = new List<message /> ();
    //        this.RoomID = roomID;
    //        userChatRoomSessionTimeout = Int32.Parse
    //            (System.Configuration.ConfigurationManager.AppSettings
    //            ["UserChatRoomSessionTimeout"]);
    //        RoomUsers = new Dictionary<string, chatuser />
    //            (Int32.Parse(System.Configuration.ConfigurationManager.AppSettings
    //            ["ChatRoomMaxUsers"]));
    //    }
    //}

    //public void LeaveRoom(string userID)
    //{
    //    ChatUser user = this.GetUser(userID);
    //    if (user == null)
    //        return;
    //    user.IsActive = false;
    //    user.LastSeen = DateTime.Now;
    //    this.RoomUsers.Remove(userID);

    //    Message msg = new Message(user.UserName, "", MsgType.Left);
    //    this.AddMsg(msg);

    //    if (IsEmpty())
    //        ChatEngine.DeleteRoom(this.RoomID);
    //}

    //public string JoinRoom(string userID,string userName)
    //{
    //    ChatUser user = new ChatUser(userID, userName);
    //    user.IsActive = true;
    //    user.UserName = userName;
    //    user.LastSeen = DateTime.Now;
    //    if (!this.RoomUsers.ContainsKey(userID))
    //    {
    //        Message msg = new Message(user.UserName, "", MsgType.Join);
    //        this.AddMsg(msg);
    //        int lastMsgID;
    //        List < message /> previousMessages =
    //            this.GetMessagesSince(-1, out lastMsgID);
    //        user.LastMessageReceived = lastMsgID;
    //        string str = GenerateMessagesString(previousMessages);
    //        this.RoomUsers.Add(userID, user);
    //        return str;
    //    }
    //    return "";
    //}

    //public string SendMessage(string strMsg,string senderID)
    //{
    //    ChatUser user = this.GetUser(senderID);
    //    Message msg = new Message(user.UserName, strMsg, MsgType.Msg);
    //    user.LastSeen = DateTime.Now;
    //    this.ExpireUsers(userChatRoomSessionTimeout);
    //    this.AddMsg(msg);
    //    int lastMsgID;
    //    List < message /> previousMsgs = this.GetMessagesSince
    //        (user.LastMessageReceived, out lastMsgID);
    //    if (lastMsgID != -1)
    //        user.LastMessageReceived = lastMsgID;
    //    string res = this.GenerateMessagesString(previousMsgs);
    //    return res;
    //}

    //public void ExpireUsers(int window)
    //{
    //    lock(this)
    //    {
    //        foreach (object key in RoomUsers.Keys)
    //        {
    //            ChatUser usr = this.RoomUsers[key.ToString()];
    //            lock (usr)
    //            {
    //                if (usr.LastSeen != System.DateTime.MinValue)
    //                {
    //                    TimeSpan span = DateTime.Now - usr.LastSeen;
    //                    if (span.TotalSeconds > window && usr.IsActive != false)
    //                    {
    //                        this.LeaveRoom(usr.UserID);
    //                    }
    //                }
    //            }
    //        }
    //    }
//    }
}