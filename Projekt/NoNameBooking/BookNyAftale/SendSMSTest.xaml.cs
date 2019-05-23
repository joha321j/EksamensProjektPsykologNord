using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for SendSMSTest.xaml
    /// </summary>
    public partial class SendSMSTest : Window
    {
        public SendSMSTest()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            sendSMS(txtBoxPN.Text, TxtBoxMessage.Text, TxtBoxSender.Text);
            MessageBox.Show("Your message is send", "Yup", MessageBoxButton.OK);
        }

        private string sendSMS(string number, string message, string sender)
        {
            String result;
            string apiKey = "luX4Vues7gY-QWJjpXenp4abs3qR9i0iQqAfJ5TbfG";
            

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + number + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }
    }
}
