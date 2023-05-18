using System.Collections;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;


namespace ClientChat
{
    public partial class LoginForm : Form
    {
        IPEndPoint iep;
        TcpClient client;
        StreamReader sr;
        StreamWriter sw;
        String ip, port;
        public LoginForm()
        {
            InitializeComponent();
            port = "2008";
            portTxt.Text = port;
          
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            if (ipTxt.Text == "" || userTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Không bỏ trống các ô.");
            }
            else
            {
                iep = new IPEndPoint(IPAddress.Parse(ipTxt.Text), int.Parse(port));
                client = new TcpClient();
                client.Connect(iep);
                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());

                var data = new Message
                {
                    ToSide = "Server",
                    FromSide = userTxt.Text,
                    TimeSend = DateTime.Now,
                    TypeMessage = "SIGNUP_REQ",
                    StatusSend = true,
                    ContentSend = userTxt.Text + ":" + passTxt.Text
                };
                string loginReq = JsonSerializer.Serialize(data);
                sw.WriteLine(loginReq);
                sw.Flush();
                string repone = "";
                repone = sr.ReadLine();
                Message loginRes = JsonSerializer.Deserialize<Message>(repone);
                if (loginRes.TypeMessage == "SIGNUP_RES" && loginRes.StatusSend == true)
                {
                    MessageBox.Show("Thành Công");
                }
                else
                {
                    if (loginRes.TypeMessage == "SIGNUP_RES" && loginRes.StatusSend == false)
                    {
                        MessageBox.Show("Username đã tồn tại.");
                    }

                }

            }

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (ipTxt.Text == "" || userTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Không bỏ trống các ô.");
            }
            else
            {
                iep = new IPEndPoint(IPAddress.Parse(ipTxt.Text), int.Parse(port));
                client = new TcpClient();
                client.Connect(iep);
                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());

                var data = new Message
                {
                    ToSide = "Server",
                    FromSide = userTxt.Text,
                    TimeSend = DateTime.Now,
                    TypeMessage = "LOGIN_REQ",
                    StatusSend = true,
                    ContentSend = userTxt.Text + ":" + passTxt.Text
                };
                string loginReq = JsonSerializer.Serialize(data);
                sw.WriteLine(loginReq);
                sw.Flush();
                string repone = "";
                repone = sr.ReadLine();
                Message loginRes = JsonSerializer.Deserialize<Message> (repone);
                if (loginRes.TypeMessage == "LOGIN_RES" &&  loginRes.StatusSend == true)
                {
                    string userlistres = sr.ReadLine();
                    string groupList = sr.ReadLine();
                    Message userlistresJson = JsonSerializer.Deserialize<Message> (userlistres);
                    Message groupListJson = JsonSerializer.Deserialize<Message>(groupList);
                    string[] tmpList = userlistresJson.ContentSend.Split(":");
                    string[] groups = groupListJson.ContentSend.Split(':');
                    ArrayList groupArrList = new ArrayList();
                    ArrayList tmpArr = new ArrayList();
                    tmpArr.AddRange(tmpList);
                    groupArrList.AddRange(groups);
                    this.Visible = false;
                    ChatApp chatApp = new ChatApp(iep, client, sr, sw, tmpArr, groupArrList,userlistresJson.ToSide);
                    chatApp.ShowDialog();
                } else
                {
                    if (loginRes.TypeMessage == "LOGIN_RES" && loginRes.StatusSend == false)
                    {
                        MessageBox.Show("Thất bại");
                    }

                }
               
            }

        }



    }
}