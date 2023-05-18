using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text;
using System;
using System.Reflection;

namespace ServerChat
{
    public partial class Form1 : Form
    {
        private String port = "2008";
        private String ip;
        private delegate void SafeCallDelegate(string text);
        public delegate void dgAddToList(string Message);
        IPEndPoint iep;
        TcpListener server;
        public static ArrayList clientList;
        public static ArrayList groupList;
        ArrayList clientData;
        struct ClientInfo
        {
            public TcpClient clientProtocol;
            public string clientName;
            public StreamReader sr;
            public StreamWriter sw;
            public void ThreadClient()
            {
                bool running = true;
                while (running)
                {
                    string? s = "";
                    try
                    {
                        s = sr.ReadLine();
                    } catch (IOException e)
                    { 
                        foreach (ClientInfo index in clientList)
                        {
                            if (index.clientName == this.clientName)
                            {
                                clientList.Remove(index);
                                break;                            
                            }
                        }
                        running = false;
                        break;
                    }
                    if (running == true && s!="")
                    {
                  
                        Message m = JsonSerializer.Deserialize<Message>(s);
                        if (m.TypeMessage == "SEND")
                        {
                            foreach (ClientInfo index in Form1.clientList)
                            {
                                if (index.clientName == m.ToSide)
                                {
                                    var tranfer = new Message
                                    {
                                        ToSide = m.ToSide,
                                        FromSide = m.FromSide,
                                        TimeSend = m.TimeSend,
                                        TypeMessage = "SEND",
                                        StatusSend = true,
                                        ContentSend = m.ContentSend
                                    };
                                    string jsonstr = JsonSerializer.Serialize(tranfer);
                                    index.sw.WriteLine(jsonstr);
                                    index.sw.Flush();

                                }
                            }
                        } else if (m.TypeMessage == "SEND_EMOJI")
                        {
                            foreach (ClientInfo index in Form1.clientList)
                            {
                                if (index.clientName == m.ToSide)
                                {
                                    var tranfer = new Message
                                    {
                                        ToSide = m.ToSide,
                                        FromSide = m.FromSide,
                                        TimeSend = m.TimeSend,
                                        TypeMessage = "SEND_EMOJI",
                                        StatusSend = true,
                                        ContentSend = m.ContentSend
                                    };
                                    string jsonstr = JsonSerializer.Serialize(tranfer);
                                    index.sw.WriteLine(jsonstr);
                                    index.sw.Flush();

                                }
                            }

                        } else if  (m.TypeMessage == "SEND_FILE")
                        {
                            string contentFile = sr.ReadLine();
                            foreach (ClientInfo index in Form1.clientList)
                            {
                                if (index.clientName == m.ToSide)
                                {
                                    var tranfer = new Message
                                    {
                                        ToSide = m.ToSide,
                                        FromSide = m.FromSide,
                                        TimeSend = m.TimeSend,
                                        TypeMessage = "SEND_FILE",
                                        StatusSend = true,
                                        ContentSend = m.ContentSend
                                    };
                                    string jsonstr = JsonSerializer.Serialize(tranfer);
                                    index.sw.WriteLine(jsonstr);
                                    index.sw.WriteLine(contentFile);
                                    index.sw.Flush();

                                }
                            }
                        }
                        else if (m.TypeMessage == "SEND_GROUP")
                        {
                            
                          
                            foreach(GroupInfo g_index in groupList)
                            {
                                if (m.ToSide == g_index.groupName )
                                {
                                    foreach(String member_index in g_index.members)
                                    {
                                        foreach(ClientInfo client_index in clientList)
                                        {
                                            if (client_index.clientName == member_index && client_index.clientName != m.FromSide)
                                            {
                                                var tranfer = new Message
                                                {
                                                    ToSide = member_index,
                                                    FromSide = m.FromSide,
                                                    TimeSend = m.TimeSend,
                                                    TypeMessage = "SEND_GROUP",
                                                    StatusSend = true,
                                                    ContentSend = m.ContentSend
                                                };
                                                string jsonstr = JsonSerializer.Serialize(tranfer);
                                                client_index.sw.WriteLine(jsonstr);
                                                client_index.sw.Flush();
                                                break;
                                            }
                                        }

                                    }
                                    break;
                                }
                                   
                                
                            }
                        }
                       
                    }
                }
                sr.Close();
                sw.Close();
                clientProtocol.Close();
            }
        }

        struct GroupInfo
        {
            public string groupName;
            public ArrayList members;
        }
        public Form1()
        {
            
            InitializeComponent();
            this.ip = getIP();
            this.ipTxt.Text = this.ip;
            this.portTxt.Text = this.port;
            clientList = new ArrayList();
            groupList = new ArrayList();
            readFile();
            readFileGroup();
        }
        private void readFile()
        {
            clientData = new ArrayList();
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead("./user.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    clientData.Add(line);
                }
            }
        }
        private void readFileGroup()
        {
            clientData = new ArrayList();
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead("./group.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] groupRawData = line.Split(':');
                    string[] memberList = groupRawData[1].Split('-');
                    GroupInfo group = new GroupInfo();
                    group.groupName = groupRawData[0];
                    group.members = new ArrayList();
                    group.members.AddRange(memberList);
                    groupList.Add(group);
                }
            }
        }
        private void writeFile(string info)
        {
            using (StreamWriter writer = new StreamWriter("./user.txt", true))
            {
                writer.WriteLine(info);
            }
        }
        private string getIP()
        {
            string hostName = Dns.GetHostName(); 

            IPAddress[] ipList = Dns.GetHostByName(hostName).AddressList;
            string myIP = "undefined";
            foreach (IPAddress element in ipList)
            {
                if (element.ToString().Contains('.'))
                {
                    myIP = element.ToString();
                    break;
                }
            }
            return myIP;
        }
        public void AddToList(String Message)
        {
            if (CurrentOnlineUser.InvokeRequired)
            {
                CurrentOnlineUser.BeginInvoke(new dgAddToList(AddToList), new object[] { Message });
            }
            else
            {
                CurrentOnlineUser.Items.Clear();
                foreach(ClientInfo index in Form1.clientList)
                {
                    CurrentOnlineUser.Items.Add(index.clientName);  
                }
            }
        }
        
        private bool checkLogin(String info)
        {
            if (clientData.IndexOf(info) >= 0)
            {
                return true;
            }
            return false;
        }
        private bool checkUnique(String info)
        {
            string username = info.Split(':')[0];
            foreach (String index in clientData)
            {
                string index_username = index.Split(":")[0];
                if (index_username == username)
                {
                    return false;
                }
            }
            return true;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            readFile();
            iep = new IPEndPoint(IPAddress.Parse(this.ip), int.Parse(this.port));
            server = new TcpListener(iep);
            server.Start();
            Thread trd = new Thread(new ThreadStart(this.ThreadServer));
            trd.IsBackground = true;
            trd.Start();
        }
        private void ThreadServer()
        {
            do
            {
                TcpClient client = server.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                ClientInfo clientInfo = new ClientInfo();
                string str = sr.ReadLine();
                Message mess = JsonSerializer.Deserialize<Message>(str);
                if (mess.TypeMessage == "LOGIN_REQ")
                {
                    clientInfo.clientProtocol = client;
                    clientInfo.sr = sr;
                    clientInfo.sw = sw;
                    clientInfo.clientName = mess.FromSide;
                    string loginInfo = mess.ContentSend;
                    if (this.checkLogin(loginInfo))
                    {
                        Form1.clientList.Add(clientInfo);
                        AddToList(clientInfo.clientName);
                        string userList = "";
                            string groups = "";
                        foreach (ClientInfo index in clientList)
                        {
                            userList += index.clientName + ":";
                        }
                        foreach(GroupInfo index in groupList)
                            {
                                groups += index.groupName + ":";
                            }
                        userList = userList.TrimEnd(':');
                        var succesLogin = new Message
                        {
                            ToSide = clientInfo.clientName,
                            FromSide = "Server",
                            TimeSend = DateTime.Now,
                            TypeMessage = "LOGIN_RES",
                            StatusSend = true,
                            ContentSend = "Thành Công."
                        };
                        string successLoginStr = JsonSerializer.Serialize(succesLogin);
                        clientInfo.sw.WriteLine(successLoginStr);
                        clientInfo.sw.Flush();
                        
                        
                        foreach (ClientInfo index in clientList)
                        {
                            var tranfer = new Message
                            {
                                ToSide = index.clientName,
                                FromSide = "Server",
                                TimeSend = DateTime.Now,
                                TypeMessage = "USERLIST",
                                StatusSend = true,
                                ContentSend = userList
                            };
                            string onlineList = JsonSerializer.Serialize(tranfer);
                             var tranferGroup = new Message
                                {
                                    ToSide = index.clientName,
                                    FromSide = "Server",
                                    TimeSend = DateTime.Now,
                                    TypeMessage = "GROUPLIST",
                                    StatusSend = true,
                                    ContentSend = groups
                                };
                           string groupList = JsonSerializer.Serialize(tranferGroup);
                            index.sw.WriteLine(onlineList);
                            index.sw.WriteLine(groupList);
                            index.sw.Flush();


                        }

                        var t = new Thread(() => clientInfo.ThreadClient());
                        t.Start();
                    }
                    else
                    {
                        var tranfer = new Message
                        {
                            ToSide = clientInfo.clientName,
                            FromSide = "Server",
                            TimeSend = DateTime.Now,
                            TypeMessage = "LOGIN_RES",
                            StatusSend = false,
                            ContentSend = "Thất Bại!"
                        };
                        string failLoginRes = JsonSerializer.Serialize(tranfer);
                        clientInfo.sw.WriteLine(failLoginRes);
                        clientInfo.sw.Flush();
                    }
                }
                else if (mess.TypeMessage == "SIGNUP_REQ")
                {
                    clientInfo.clientProtocol = client;
                    clientInfo.sr = sr;
                    clientInfo.sw = sw;
                    clientInfo.clientName = mess.FromSide;
                    string signUpInfo = mess.ContentSend;
                    if (checkUnique(signUpInfo) == true)
                    {
                        writeFile(signUpInfo);
                        readFile();
                        var tranfer = new Message
                        {
                            ToSide = mess.FromSide,
                            FromSide = "Server",
                            TimeSend = DateTime.Now,
                            TypeMessage = "SIGNUP_RES",
                            StatusSend = true,
                            ContentSend = "Thành Công"
                        };
                        string successSignup = JsonSerializer.Serialize(tranfer);
                        clientInfo.sw.WriteLine(successSignup);
                        clientInfo.sw.Flush();
                    }
                    else
                    {
                        var tranfer = new Message
                        {
                            ToSide = mess.FromSide,
                            FromSide = "Server",
                            TimeSend = DateTime.Now,
                            TypeMessage = "SIGNUP_RES",
                            StatusSend = false,
                            ContentSend = "Thất Bại"
                        };
                        string failSignup = JsonSerializer.Serialize(tranfer);
                        clientInfo.sw.WriteLine(failSignup);
                        clientInfo.sw.Flush();
                    }
                }
                else if (mess.TypeMessage == "LOGOUT")
                {
                    for (int index = 0; index < clientList.Count; index++)
                    {
                        ClientInfo tmp = (ClientInfo)clientList[index];
                        if (tmp.clientName == mess.ContentSend)
                        {
                            clientList.RemoveAt(index);
                        }
                    }
                    AddToList("Remove");

                }

            }
            while (true);
        }

        private void CurrentOnlineUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}