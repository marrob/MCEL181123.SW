using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MCEL181123
{
    using NUnit.Framework;
    using System.Diagnostics;
    using System.Text;

    [TestFixture]
    class UintTest
    {
        [Test]
        public void first()
        {
            var de = new DeviceExplorer();

            de.ParseFrame(0x00000100, new byte[] { 0x00, 0x01 });
            de.ParseFrame(0x00000100, new byte[] { 0x00, 0x01 });
        }
    }
}
