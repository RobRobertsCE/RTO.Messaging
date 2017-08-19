using RTO.Messaging.Ports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTO.Messaging.TestApp
{
    public partial class Form1 : Form
    {
        IMessageService _service;

        public Form1()
        {
            InitializeComponent();

            _service = (IMessageService)Program.Services.ServiceProvider.GetService(typeof(IMessageService));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var address1 = _service.GetAddress(Guid.NewGuid(), "Foo Bar");
            var msg = _service.CreateNewMessage(address1);
            msg.Subject = "The Subject";
            msg.Body = "The Body";
            var address2 = _service.GetAddress(Guid.NewGuid(), "Foo Bar Jr.");
            msg.Recipients.Add(address2);
            _service.SendMessage(msg);

            var msgs =_service.GetAllMessages(address2);

            foreach (var m in msgs)
            {
                Console.WriteLine("{0} {1}", m.Subject, m.Body);
            }
        }
    }
}
