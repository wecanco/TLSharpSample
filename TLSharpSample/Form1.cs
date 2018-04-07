using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TeleSharp.TL.Channels;
using TeleSharp.TL.Messages;
using TeleSharp.TL.Updates;
using TLSharp;
using TLSharp.Core;


namespace TLSharpSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TelegramClient Client;
        ISessionStore store = null;
        string hash = null;
        string MyPhone = "";
        TLUser user = null;
        bool getupdates = false;
        
        Dictionary<int, long> MyDialogs = null;

 
        private TcpClient conectarProxy(string httpProxyHost, int httpProxyPort)
        {
            var url = "http://" + httpProxyHost + ":" + httpProxyPort;
            var proxyUrl = WebRequest.DefaultWebProxy.GetProxy(new Uri(url));
            WebResponse response = null;
            var tentativas = 10;

            while (tentativas >= 0)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = true;
                var webProxy = new WebProxy(proxyUrl);
                request.Proxy = webProxy;
                request.Method = "CONNECT";
                request.Timeout = 3000;

                tentativas--;
                try
                {
                    response = request.GetResponse();
                    break;
                }
                catch (Exception ex)
                {
                    if (tentativas >= 0 && ex.Message.Equals("The operation has timed out", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Ocorreu timeout ao tentar se conectar pelo proxy.");
                    }
                    else
                    {
                        throw new Exception("Algo deu errado", ex);
                    }
                }
            }
            var responseStream = response.GetResponseStream();
            Debug.Assert(responseStream != null);

            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var rsType = responseStream.GetType();
            var connectionProperty = rsType.GetProperty("Connection", Flags);

            var connection = connectionProperty.GetValue(responseStream, null);
            var connectionType = connection.GetType();
            var networkStreamProperty = connectionType.GetProperty("NetworkStream", Flags);

            var networkStream = networkStreamProperty.GetValue(connection, null);
            var nsType = networkStream.GetType();
            var socketProperty = nsType.GetProperty("Socket", Flags);
            var socket = (Socket)socketProperty.GetValue(networkStream, null);

            return new TcpClient { Client = socket };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string grhash = GHash.Text.Trim().Replace("https://t.me/joinchat/", "").Replace("/","");
            TLRequestImportChatInvite RCHI = new TLRequestImportChatInvite();
            RCHI.hash = grhash;

            TLUpdates chat = await Client.SendRequestAsync<TLUpdates>(RCHI);
            
   
        }

        private async void ConnectB_Click(object sender, EventArgs e)
        {
            MyPhone = phone.Text.Trim().Replace(" ", "");
            if (MyPhone !="") {
                string sessionName = MyPhone.Replace("+", "_") + ".wecan";
                //TcpClient TcpC = conectarProxy("",0);

                TLSharp.Core.Network.TcpClientConnectionHandler TcpHandler = new TLSharp.Core.Network.TcpClientConnectionHandler(conectarProxy);
                Client = new TelegramClient(185606, "c7351fb30842b4abb27c72e5e1680506", store, sessionName, TcpHandler);
                await Client.ConnectAsync();
                if (Client.IsUserAuthorized())
                {
                    ConnectB.Text = MyPhone+" متصل شد.";
                    ConnectB.BackColor = Color.Green;
                    //await Task.Delay(4000);
                    await GetDialogs();
                    StopTimer_Click(sender, e);
                }
                else
                {
                    code.Enabled = true;
                    CodeOK.Enabled = true;
                    hash = await Client.SendCodeRequestAsync(MyPhone);
                    
                } 

            }
            else
            {
                phone.Focus();
            }

        }

        private async void CodeOK_Click(object sender, EventArgs e)
        {
            user = await Client.MakeAuthAsync(MyPhone, hash, code.Text.Trim().Replace(" ", ""));
            if (user.id > 0)
            {
                code.Enabled = false;
                CodeOK.Enabled = false;
                ConnectB.Text = MyPhone + " متصل شد.";
                ConnectB.BackColor = Color.Green;
                await GetDialogs();
                StopTimer_Click(sender, e);
            }
            
        }

        private async Task GetDialogs()
        {
           // TLAbsDialogs Dialogs = await Client.GetUserDialogsAsync();
            var peer = new TLInputPeerSelf();
            var Dialogs = await Client.SendRequestAsync<TLAbsDialogs>(new TLRequestGetDialogs() { offset_date = 0, offset_peer = peer, limit = 1000 });
            TLDialogs Dlogs = Dialogs as TLDialogs;
            int i = 0;
            MyDialogs = new Dictionary<int, long>();
            if (Dlogs != null)
            {
                foreach (TLUser user in Dlogs.users.lists)
                {
                    try
                    {
                        MyDialogs.Add(user.id, (long)user.access_hash);
                    }
                    catch (Exception ex)
                    {

                    }
                    i++;
                }
                
            }
            DialogsCountL.Text = "کل چت ها: " + i;

        }
        private async Task GetMessages()
        {
            try
            {

                TLAbsDialogs Dialogs = await Client.GetUserDialogsAsync();
                TLDialogs Dlogs = Dialogs as TLDialogs;
                int i = 0;
                foreach (TLUser user in Dlogs.users.lists)
                {
                    TLAbsMessages messages = null;
                    string type = (Dlogs.dialogs.lists[i].peer.GetType() + "").Replace("TeleSharp.TL.", "");
                    string peerID = "";
                    //MessageBox.Show(type);
                    
                    switch (type)
                    {
                        case "TLPeerUser":
                            TLInputPeerUser ipeer = new TLInputPeerUser();
                            ipeer.access_hash = (long)user.access_hash;
                            ipeer.user_id = user.id;
                            peerID = user.id + "";
                            messages = await Client.GetHistoryAsync(ipeer, 0, 999999, 1);
                            break;
                        case "TLPeerChannel":
                            break;
                        case "TLPeerChat":
                            break;
                        case "TLPeerNotifyEventsAll":
                            break;
                        case "TLPeerNotifyEventsEmpty":
                            break;
                        case "TLPeerNotifySettings":
                            break;
                        case "TLPeerNotifySettingsEmpty":
                            break;
                        case "TLPeerSettings":
                            break;
                        default:

                            break;
                    }



                    if (messages != null)
                    {

                        try
                        {
                            TLMessages msgs = messages as TLMessages;
                            TLMessagesSlice msgs2 = messages as TLMessagesSlice;
                            if (msgs != null)
                            {
                                foreach (var msg in msgs.messages.lists)
                                {
                                    string uniq = "";
                                    TLMessage msgg = msg as TLMessage;
                                    if (msgg != null)
                                    {
                                        uniq = peerID + "_" + msgg.id + "# " + msgg.message;

                                        if (UpdatesList.Items.IndexOf(uniq) < 0)
                                        {
                                            UpdatesList.Items.Add(uniq);
                                        }
                                    }
                                }
                            }
                            else if(msgs2 != null)
                            {
                                foreach (var msg in msgs2.messages.lists)
                                {
                                    string uniq = "";
                                    TLMessage msgg = msg as TLMessage;
                                    if (msgg != null)
                                    {
                                        uniq = peerID + "_" + msgg.id + "# " + msgg.message;

                                        if (UpdatesList.Items.IndexOf(uniq) < 0)
                                        {
                                            UpdatesList.Items.Add(uniq);
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            ErrorsBox.Items.Add(ex.Message);
                        }


                    }

                    i++;

                }
                //await GetUpdates();
            }
            catch (Exception ex){
                ErrorsBox.Items.Add(ex.Message);
            }

        }

        private async Task get_updates()
        {
            
            while (getupdates)
            {
                var state = await Client.SendRequestAsync<TLState>(new TLRequestGetState());
                TLRequestGetDifference req = new TLRequestGetDifference();
                req.date = state.date;
                req.pts = state.pts-1;
                req.qts = state.qts-1;

                var adiff = await Client.SendRequestAsync<TLAbsDifference>(req);
                if (!(adiff is TLDifferenceEmpty))
                {
                    if (adiff is TLDifference)
                    {
                        var diff = adiff as TLDifference;
                        string uniq = "";
                        uniq += ("chats:" + diff.chats.lists.Count);
                        uniq += (" new:" + diff.new_messages.lists.Count);
                        uniq += (" user:" + diff.users.lists.Count);
                        uniq += (" other:" + diff.other_updates.lists.Count);

                        if (diff.new_messages.lists.Count > 0)
                        {

                            foreach (var upd in diff.new_messages.lists)
                            {
                                TLMessage msg = (upd as TLMessage);
                                uniq = msg.from_id.Value + "_" + msg.id + ": " + (msg.message);

                                if (UpdatesList.Items.IndexOf(uniq) < 0 && msg.message != "") {
                                    UpdatesList.Items.Insert(0, uniq);
                                    string replay = "";
                                    TLInputPeerUser peer = new TLInputPeerUser();

                                    foreach (string item in ReplisBox.Items)
                                    {
                                        string[] st = item.Split('#');
                                        if(st[0] == msg.message.Trim())
                                        {
                                            if (MyDialogs.ContainsKey(msg.from_id.Value))
                                            {

                                            }
                                            else
                                            {
                                                await GetDialogs();
                                                
                                            }
                                            replay = st[1];
                                            peer.access_hash = MyDialogs[msg.from_id.Value];
                                            peer.user_id = msg.from_id.Value;
                                        }
                                    }


                                    if (replay != "")
                                    {
                                        await Client.SendMessageAsync(peer, replay);
                                    }
                                }

                            }

                        }


                    }
                    else if (adiff is TLDifferenceTooLong)
                    {
                        ErrorsBox.Items.Add("too long");
                        //Console.WriteLine("too long");
                    }
                    else if (adiff is TLDifferenceSlice)
                    {
                        //Console.WriteLine("slice");
                        ErrorsBox.Items.Add("slice");
                        
                    }
                }
                //await Task.Delay(500);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            phone.Items.Clear();
            String[] allfiles = System.IO.Directory.GetFiles(Application.StartupPath, "*.wecan.dat", System.IO.SearchOption.AllDirectories);
            foreach (var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                phone.Items.Add(info.Name.Replace(".wecan.dat", "").Replace("_","+"));
            }
            
        }



        private async void StopTimer_Click(object sender, EventArgs e)
        {
            if (getupdates)
            {
                getupdates = false;
                StopTimer.Text = "روشن کردن";
                StopTimer.BackColor = Color.LightGray;
            }
            else
            {
                getupdates = true;
                StopTimer.Text = "خاموش کردن";
                StopTimer.BackColor = Color.Green;
                await get_updates();
            }

        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private void donate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("با کمک حداقلی،نقشی در توسعه این کتابخانه داشته باشید. کمک شما امیدی برای توسعه است.");
            System.Diagnostics.Process.Start("http://wecan-co.ir/payment");
        }

        private void AddReply_Click(object sender, EventArgs e)
        {
            if (ReplyText.Text.Trim() !="")
            {
                ReplisBox.Items.Add(ReplyText.Text+"#");
                ReplyText.Text = "";
            }
        }

        private void ReplisBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(ReplisBox.SelectedIndex >= 0)
            {
                ReplisBox.Items.RemoveAt(ReplisBox.SelectedIndex);
            }
        }



    }
}
