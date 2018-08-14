using jabber.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcm_JabberNet_Connect
{
    class Program
    {
        static string senderId = "";//replace with your sender id
        static string serverKey = "";//replace with your server key
        //static string testDeviceId = 
        static void Main(string[] args)
        {
            JabberClient jabberClient1 = new JabberClient();

            jabberClient1.Server = "gcm.googleapis.com";
            jabberClient1.NetworkHost = "fcm-xmpp.googleapis.com";
            jabberClient1.Port = 5236;

            jabberClient1.SSL = true;
            //xmppClient.OldStyleSsl = true;

            jabberClient1.User = senderId;     // your sender id
            jabberClient1.Password = serverKey;    // your server key

            jabberClient1.AutoRoster = false;
            jabberClient1.AutoPresence = false;

            jabberClient1.OnMessage += new MessageHandler(jabberClient1_OnMessage);
            jabberClient1.OnDisconnect += new bedrock.ObjectHandler(jabberClient1_OnDisconnect);
            jabberClient1.OnError += new bedrock.ExceptionHandler(jabberClient1_OnError);
            jabberClient1.OnAuthError += new jabber.protocol.ProtocolHandler(jabberClient1_OnAuthError);
            jabberClient1.OnReadText += new bedrock.TextHandler(jc_OnReadText);
            jabberClient1.OnWriteText += new bedrock.TextHandler(jc_OnWriteText);

            jabberClient1.Connect();

            Console.WriteLine("Press return key to exit the application");
            Console.ReadLine();

            jabberClient1.Close();
        }

        private static void jabberClient1_OnMessage(object sender, jabber.protocol.client.Message msg)
        {

            Console.WriteLine
                 ("RECV: " + msg);
        }

        static void jabberClient1_OnDisconnect(object sender)
        {

        }

        static void jabberClient1_OnError(object sender, Exception ex)
        {
            Console.WriteLine("Error: " + sender);
        }

        static void jabberClient1_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            Console.WriteLine("Error Auth:" + rp);
        }

        private static void jc_OnReadText(object sender, string txt)
        {
                Console.WriteLine("RECV: " + txt);
        }

        private static void jc_OnWriteText(object sender, string txt)
        {
                Console.WriteLine("SENT: " + txt);
        }
    }
}
