using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Buffers.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ClientChat
{
    public partial class ChatApp : Form
    {
       
        private delegate void SafeCallDelegate(string text);
        public delegate void dgAddToList(string Message);
        public delegate void dgAddToGList(ArrayList list);
        public delegate string getSelectItemListBox();
        public delegate void reloadScreen();
        IPEndPoint iep;
        TcpClient client;
        StreamReader sr;
        StreamWriter sw;
        ArrayList clientList, groupList;
        ArrayList screenChatGList;
        ArrayList fileList;
        string tmp = "";
        string clientName = "";
        string targetReceiveType = "";


        struct ScreenChat
        {
            public string clientName;
            public string clientMess;
         }
        struct FileInfo
        {
            public string FileName;
            public byte[] data;
        }
         public ChatApp(IPEndPoint iepparam, TcpClient clientparam, StreamReader srparam, StreamWriter swparam, ArrayList clientListParam,ArrayList groupListParam ,String clientNameParam)
         {
            InitializeComponent();
            this.iep = iepparam;
            this.client = clientparam;
            this.sr= srparam;
            this.sw = swparam;  
            this.clientList = new ArrayList();
            this.groupList = groupListParam;
            this.clientName = clientNameParam;
            this.yournameLb.Text = clientName;
            this.fileList = new ArrayList();
            this.screenChatGList = new ArrayList();
            string usrList = "";
            foreach (string index in clientListParam) {
                usrList+= index+ ":";
            }
            usrList.Trim(':');
            AddToList(usrList);
            AddToGroupList(groupList);

            foreach (string index in clientListParam)
            {
                ScreenChat screenChat = new ScreenChat();
                screenChat.clientName = index;
                screenChat.clientMess = "";
                this.clientList.Add(screenChat);

            }
            foreach (string index in groupList)
            {
                ScreenChat screenChat = new ScreenChat();
                screenChat.clientName = index;
                screenChat.clientMess = "";
                this.screenChatGList.Add(screenChat);

            }
            var t = new Thread(() => ThreadClient());
            t.Start();

        }
      
        private string getSelectItemFriendList()
        {
            if (Friend.InvokeRequired)
            {
                var dlg = new getSelectItemListBox(getSelectItemFriendList);
                return (string)Friend.Invoke(dlg);
            }
            string result = Friend.SelectedItem.ToString();
            return result;
        }
        private string getSelectItemGroupList()
        {
            if (Group.InvokeRequired)
            {
                var dlg = new getSelectItemListBox(getSelectItemGroupList);
                return (string)Group.Invoke(dlg);
            }
            string result = Group.SelectedItem.ToString();
            return result;
        }
        private void reloadScreenFriend()
        {
            if (Friend.InvokeRequired)
            {
                var dlg = new reloadScreen(reloadScreenFriend);
                Friend.Invoke(dlg);
            }
            else
            {
                Friend.SelectedIndex = Friend.SelectedIndex;
            }     
                
        }
        private void AddToGroupList(ArrayList list)
        {
            ArrayList newGroupList = new ArrayList();
            if (Group.InvokeRequired)
            {
                Group.BeginInvoke(new dgAddToGList(AddToGroupList), new object[] { list });
            }
            else
            {
                Group.Items.Clear();
                for (int index = 0; index < groupList.Count; index++)
                {
                    Group.Items.Add(groupList[index]);
                    ScreenChat screenChat = new ScreenChat();
                    screenChat.clientName = (string?)groupList[index];
                    int checker = checkExistGroupname(screenChat.clientName);
                    if (checker != -1)
                    {
                        ScreenChat temp = (ScreenChat)clientList[checker];
                        screenChat.clientMess = temp.clientMess;
                    }
                    else
                    {
                        screenChat.clientMess = "";
                    }
                    newGroupList.Add(screenChat);

                }    
                
                screenChatGList.Clear();
                screenChatGList = newGroupList;
            }

        }
        private void WriteLinkSafe(String text)
        {
            if (display.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteLinkSafe);
                display.Invoke(d, new object[] { text });
            }
            else
            {
                string[] messInfo = text.Split(":");
                string[] namePath = messInfo[3].Split("\\");
                string name = namePath[namePath.Length -1];
                if (messInfo[0] == "Tôi")
                {
                   
                    display.AppendText(messInfo[0] + ": ", Color.Blue);
                    display.AppendText(messInfo[1] + ":"+ name);

                }
                else
                {
                    display.AppendText(messInfo[0] + ": ", Color.Red);
                    display.AppendText(messInfo[1] + ":" + name);


                }



            }
        }
        private void WriteTextSafe(String text)
        {
            if (display.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                display.Invoke(d, new object[] { text });
            }
            else
            {
                string[] messInfo = text.Split(":");
                if (messInfo[0] == "Tôi")
                {
                    display.AppendText(messInfo[0]+": ", Color.Blue);
                    display.AppendText(messInfo[1]+": ");
                    display.AppendText(messInfo[2] + messInfo[3] + messInfo[4], Color.Gray);
                    
                }
                else
                {
                    display.AppendText(messInfo[0] + ": ", Color.Red);
                    display.AppendText(messInfo[1] + ": ");
                    display.AppendText(messInfo[2] + messInfo[3] + messInfo[4], Color.Gray);
                } 
            }
        }
        private void WriteEmojiSafe(String text)
        {
            if (display.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteEmojiSafe);
                display.Invoke(d, new object[] { text });
            }
            else
            {

                string[] messInfo = text.Split(":");
                if (messInfo[0] == "Tôi")
                {
                    display.AppendText(messInfo[0]+":    ", Color.Blue);
                    AppendEmoji(messInfo[1]);
                    display.AppendText(Environment.NewLine);
                }
                else
                {
                    display.AppendText(messInfo[0]+ ":   ", Color.Red);
                    AppendEmoji(messInfo[1]);
                    display.AppendText(Environment.NewLine);

                }

            }
        }
        private void ClearScreen(String mess)
        {
            if (display.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                display.Invoke(d, new object[] { mess });
            }
            else
            {
                display.Text = "";
            }
        }
        private void LoadMessage(string contentMessage)
        {
            if (display.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                display.Invoke(d, new object[] { contentMessage });
                
            }
            else
            {
                    display.Clear();
                    display.Text = contentMessage;
            }
        }
        public int checkExistUsername(string username)
        {
            for (int index  = 0; index < clientList.Count; index ++)
            {
                ScreenChat temp = (ScreenChat)clientList[index];
                if (temp.clientName == username)
                {
                    return index;
                } 
                    
            }
            return -1;
        }
        public int checkExistGroupname(string groupname)
        {
            for (int index = 0; index < screenChatGList.Count; index++)
            {
                ScreenChat temp = (ScreenChat)screenChatGList[index];
                if (temp.clientName == groupname)
                {
                    return index;
                }

            }
            return -1;
        }
        public void AddToList(string Message)
        {
            if (Friend.InvokeRequired)
            {
                Friend.BeginInvoke(new dgAddToList(AddToList), new object[] { Message });
            }
            else
            {
                Friend.Items.Clear();
                ArrayList newFriendList = new ArrayList();
                String[] userlist = Message.Split(':');
                for (int index = 0; index < userlist.Length; index++)
                {
                    Friend.Items.Add(userlist[index]);
                    ScreenChat screenChat = new ScreenChat();
                    screenChat.clientName = userlist[index];
                    int checker = checkExistUsername(screenChat.clientName);
                    if ( checker != -1)
                    {
                        ScreenChat temp = (ScreenChat)clientList[checker];
                        screenChat.clientMess = temp.clientMess;
                    } else
                    {
                        screenChat.clientMess = "";
                    }
                    newFriendList.Add(screenChat);
                }
                clientList.Clear();
                clientList = newFriendList;
            }
        }

        private void receivernameLb_Click(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            var sendReq = new Message
            {
                ToSide = "SERVER",
                FromSide = clientName,
                TimeSend = DateTime.Now,
                TypeMessage = "LOGOUT",
                StatusSend = true,
                ContentSend = clientName
            };
            string sendReqStr = JsonSerializer.Serialize(sendReq);
            sw.WriteLine(sendReqStr);
            sw.Flush();

            this.Visible = false;
            LoginForm lo = new LoginForm();
            lo.ShowDialog();
            
            

        }

        private void profile_Click(object sender, EventArgs e)
        {
            display.Text = tmp;
        }

        private void Friend_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.targetReceiveType = "PERSON";
            
            string slcItem = getSelectItemFriendList();
            this.receivernameLb.Text = slcItem;
            string mess = getMessageByUsername(getSelectItemFriendList());
            if (mess != "undifined_error")
            {
                LoadMessage(mess);
            }
        }

        private void Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.targetReceiveType = "GROUP";
            
            string slcItem = getSelectItemGroupList();
            this.receivernameLb.Text = slcItem;
            string mess = getMessageByGroupname(slcItem);
            if (mess != "undifined_error")
            {
                LoadMessage(mess);
            }

        }

        private void setText(String message)
        {
            WriteTextSafe(message);
        }
        private void AppendEmoji(String type)
        {
            type = type.Replace("\r\n", "").Trim();
            string bit = null;
            if (type == "SHOCK_EMOJI")
            {
              bit  = "😨";
            } else if (type == "POOP_EMOJI")
            {
                bit = "💩";
                
            } else if (type == "ANGRY_EMOJI" )
            {
                bit = "😡";
            } else if (type == "FBLOVE_EMOJI")
            {
                bit = "❤️";
            } else if (type == "CRYING_EMOJI")
            {
                bit = "😢";
            }    else if (type == "LOVE_EMOJI")
            {
                bit = "🥰";
            }
            display.AppendText(bit);
            

        }

        private string getMessageByUsername(string username)
        {
            foreach (ScreenChat index in clientList)
            {
                if (index.clientName == username)
                {
                    return index.clientMess;
                } 
                    
            }
            return "undifined_error";
        }
        private string getMessageByGroupname(string groupname)
        {
            foreach (ScreenChat index in screenChatGList)
            {
                if (index.clientName == groupname)
                {
                    return index.clientMess;
                }

            }
            return "undifined_error";
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string sendStr = inputMessTxt.Text;
            inputMessTxt.Text = "";
            if (sendStr.Trim() == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống ô gửi.");
            } else if (targetReceiveType == "")
            {
                MessageBox.Show("Vui lòng chọn người nhận/ nhóm nhận");
            } else if (targetReceiveType == "PERSON")
            {
                var sendReq = new Message
                {
                    ToSide = Friend.SelectedItem.ToString(),
                    FromSide = clientName,
                    TimeSend = DateTime.Now,
                    TypeMessage = "SEND",
                    StatusSend = true,
                    ContentSend = sendStr
                };
                string sendReqStr = JsonSerializer.Serialize(sendReq);
                sw.WriteLine(sendReqStr);
                sw.Flush();
                for (int index = 0; index < clientList.Count; index++) {
                    ScreenChat screenChat = (ScreenChat)clientList[index];
                    if (screenChat.clientName == getSelectItemFriendList())
                    {
                        string currentMess = "Tôi: " + sendStr + "-time: " + DateTime.Now+ Environment.NewLine;
                        screenChat.clientMess += currentMess;
                        clientList[index] = screenChat;
                        WriteTextSafe(currentMess);
                        break;
                    }
                } 
                    
                
            } else if (targetReceiveType == "GROUP")
            {
                var sendReq = new Message
                {
                    ToSide = Group.SelectedItem.ToString(),
                    FromSide = clientName,
                    TimeSend = DateTime.Now,
                    TypeMessage = "SEND_GROUP",
                    StatusSend = true,
                    ContentSend = sendStr
                };
                string sendReqStr = JsonSerializer.Serialize(sendReq);
                sw.WriteLine(sendReqStr);
                sw.Flush();
                for (int index = 0; index < screenChatGList.Count; index++)
                {
                    ScreenChat screenChat = (ScreenChat)screenChatGList[index];
                    if (screenChat.clientName == getSelectItemGroupList())
                    {
                        string currentMess = "Tôi: " + sendStr + "-time: " + DateTime.Now + Environment.NewLine;
                        screenChat.clientMess += currentMess;
                        clientList[index] = screenChat;
                        WriteTextSafe(currentMess);
                        break;
                    }
                }
            }
        }
        private void sendEmoji(string typeEmoji)
        {
            if (targetReceiveType == "")
            {
                MessageBox.Show("Vui lòng chọn người nhận/ nhóm nhận");
            }
            else if (targetReceiveType == "PERSON")
            {
                var sendReq = new Message
                {
                    ToSide = Friend.SelectedItem.ToString(),
                    FromSide = clientName,
                    TimeSend = DateTime.Now,
                    TypeMessage = "SEND_EMOJI",
                    StatusSend = true,
                    ContentSend = typeEmoji
                };
                string sendReqStr = JsonSerializer.Serialize(sendReq);
                sw.WriteLine(sendReqStr);
                sw.Flush();
                for (int index = 0; index < clientList.Count; index++)
                {
                    ScreenChat screenChat = (ScreenChat)clientList[index];
                    if (screenChat.clientName == getSelectItemFriendList())
                    {
                        string currentMess = "Tôi: " + typeEmoji + Environment.NewLine;
                        screenChat.clientMess += currentMess;
                        clientList[index] = screenChat;
                        WriteEmojiSafe(currentMess);
                        break;
                    }
                }
            }
           
        }

        private void shockIcon_Click(object sender, EventArgs e)
        {
            sendEmoji("SHOCK_EMOJI");
        }

        private void loveiCon_Click(object sender, EventArgs e)
        {
            sendEmoji("LOVE_EMOJI");
        }

        private void angryIcon_Click(object sender, EventArgs e)
        {
            sendEmoji("ANGRY_EMOJI");
        }

        private void poopIcon_Click(object sender, EventArgs e)
        {
            sendEmoji("POOP_EMOJI");
        }

        private void cryingIcon_Click(object sender, EventArgs e)
        {
            sendEmoji("CRYING_EMOJI");
        }

        private void fbLoveIcon_Click(object sender, EventArgs e)
        {
            sendEmoji("FBLOVE_EMOJI");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                FileInfo fileInfo = new FileInfo();
                fileInfo.FileName = openFileDialog1.FileName;
                fileInfo.data = bytes;
                if (targetReceiveType == "")
                {
                    MessageBox.Show("Vui lòng chọn người nhận/ nhóm nhận");
                }
                else if (targetReceiveType == "PERSON")
                {
                    var contentData = new FileTranfer
                    {
                        FileName = openFileDialog1.FileName,
                        Data = bytes
                    };
                    this.fileList.Add(contentData);
                    var contentDataStr = JsonSerializer.Serialize(contentData);
                    var sendReq = new Message
                    {
                        ToSide = Friend.SelectedItem.ToString(),
                        FromSide = clientName,
                        TimeSend = DateTime.Now,
                        TypeMessage = "SEND_FILE",
                        StatusSend = true,
                        ContentSend = openFileDialog1.FileName
                      
                    };
                    string sendReqStr = JsonSerializer.Serialize(sendReq);
                    sw.WriteLine(sendReqStr);
                    sw.WriteLine(Convert.ToBase64String(bytes));
                    sw.Flush();
                    for (int index = 0; index < clientList.Count; index++)
                    {
                        ScreenChat screenChat = (ScreenChat)clientList[index];
                        if (screenChat.clientName == getSelectItemFriendList())
                        {
                            string currentMess = "Tôi: " + "file:" + openFileDialog1.FileName  + Environment.NewLine;
                            screenChat.clientMess += currentMess;
                            clientList[index] = screenChat;
                            WriteLinkSafe(currentMess);
                            break;
                        }
                    }


                }

            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string[] path = e.LinkText.ToString().Split(":");
            string name = path[path.Length - 1];
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (FileTranfer index in fileList)
                {
                    string[] indexPath = index.FileName.Split("\\");
                    string indexName = indexPath[indexPath.Length - 1];
                    if (indexName == name)
                    {
                        FileStream fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                        fileStream.Write(index.Data);
                        fileStream.Close();
                    }
                }
            }

        }

        private void ThreadClient()
        {
            sr = new StreamReader(client.GetStream());

            string kq = "";

            while (true)
            {
                kq = sr.ReadLine();
                Message response = JsonSerializer.Deserialize<Message>(kq);
                if (response.TypeMessage == "USERLIST")
                {
                    
                    AddToList(response.ContentSend);
                }
                else if (response.TypeMessage == "SEND")
                {
                    string newMess = "";
                    for (int index = 0; index < clientList.Count; index++) { 
                        ScreenChat temp = (ScreenChat) clientList[index];
                        if (temp.clientName == response.FromSide)
                        {
                            newMess= response.FromSide + ": " + response.ContentSend + "- time: " + response.TimeSend + Environment.NewLine;
                            temp.clientMess += newMess;
                            WriteTextSafe(newMess);
                            clientList[index] = temp;
                            break;
                        }
                    }       
                        
                } else if (response.TypeMessage == "SEND_EMOJI")
                {
                    string newMess = "";
                    for (int index = 0; index < clientList.Count; index++)
                    {
                        ScreenChat temp = (ScreenChat)clientList[index];
                        if (temp.clientName == response.FromSide)
                        {
                            newMess = response.FromSide + ": " + response.ContentSend + Environment.NewLine;
                            temp.clientMess += newMess;
                            WriteEmojiSafe(newMess);
                            clientList[index] = temp;
                            break;
                        }
                    }

                } else if (response.TypeMessage == "SEND_FILE")
                {
                    string fileData = sr.ReadLine();
                    var file = new FileTranfer
                    {
                        FileName = response.ContentSend,
                        Data = Convert.FromBase64String(fileData)
                    };
                    string newMess = "";
                    this.fileList.Add(file);
                    for (int index = 0; index < clientList.Count; index++)
                    {
                        ScreenChat temp = (ScreenChat)clientList[index];
                        if (temp.clientName == response.FromSide)
                        {
                            newMess = response.FromSide+ ": " + "file:" + response.ContentSend + Environment.NewLine;
                            temp.clientMess += newMess;
                            WriteLinkSafe(newMess);
                            clientList[index] = temp;
                            break;
                        }
                    }
                } else if (response.TypeMessage == "SEND_GROUP")
                {
                    string newMess = "";
                    for (int index = 0; index < screenChatGList.Count; index++)
                    {
                        ScreenChat temp = (ScreenChat)screenChatGList[index];
                        if (temp.clientName == response.FromSide)
                        {
                            newMess = response.FromSide + ": " + response.ContentSend + "- time: " + response.TimeSend + Environment.NewLine;
                            temp.clientMess += newMess;
                            WriteTextSafe(newMess);
                            clientList[index] = temp;
                            break;
                        }
                    }

                }

            }
            sr.Close();
            client.Close();
        }
    }
}
