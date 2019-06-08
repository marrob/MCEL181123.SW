
namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
   


    [TestFixture]
    class UintTest
    {
        [Test]
        public void SendCanMsg()
        {
            var nodes = new NodeCollection();
            var messages = new MessageCollection();
            var signals = new SignalCollection();

            nodes.AddRange
                (
                    new NodeItem[]
                    {
                        new NodeItem(
                            name:"PC",
                            id:0x02),
                        new NodeItem(
                            name:"Device",
                            id:0x03),
                    }
                );



            messages.AddRange
                (
                    new MessageItem[]
                    {
                        new MessageItem(
                            name:"MSG_MEAS",
                            id:0x02,
                            node: nodes.FirstOrDefault(n=>n.Name == "MCEL181123")
                            ),
                        new MessageItem(
                            name:"MSG_MCEL_CV_SET",
                            id:0x03,
                            node: nodes.FirstOrDefault(n=>n.Name == "MCEL181123")
                            ),
                    }
                );

            signals.AddRange
                (
                   new SignalItem[]
                   {
                        new SignalItem(
                                    name: "SIG_MEAS_VBAT",
                                    msg: messages.FirstOrDefault(n=>n.Name == "MSG_MEAS"),
                                    defaultValue: "1",
                                    type: "UNSIGNED",
                                    startBit: 0,
                                    bits: 16,
                                    description: ""),

                       new SignalItem(
                                    name: "SIG_MEAS_RANGE",
                                    msg: messages.FirstOrDefault(n=>n.Name == "MSG_MEAS"),
                                    defaultValue: "1",
                                    type: "UNSIGNED",
                                    startBit: 17,
                                    bits: 4,
                                    description: ""),
                   }
                );


          var canMsg = CanDb.MakeMessage( nodeId: 0x05,
                            signal: signals.FirstOrDefault(n => n.Name == "SIG_MEAS_VBAT"),
                            value: "1", 
                            broadcast: false,
                            devId: 0x01);

            Assert.AreEqual(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, canMsg.Data );


            canMsg = CanDb.MakeMessage(nodeId: 0x05,
                  signal: signals.FirstOrDefault(n => n.Name == "SIG_MEAS_VBAT"),
                  value: "32768",
                  broadcast: false,
                  devId: 0x01);

            Assert.AreEqual(new byte[] { 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, canMsg.Data);

            canMsg = CanDb.MakeMessage(nodeId: 0x05,
                  signal: signals.FirstOrDefault(n => n.Name == "SIG_MEAS_VBAT"),
                  value: "65535",
                  broadcast: false,
                  devId: 0x01);

            Assert.AreEqual(new byte[] { 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, canMsg.Data);

        }
    }
}
