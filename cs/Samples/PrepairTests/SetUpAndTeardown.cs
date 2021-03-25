using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Samples.PrepairTests
{
    [TestFixture]
    public class Mailbox_Should
    {
        private Mailbox mailbox; //и после засунуть почтовый ящик в приватное поле для всех будущих тестов ниже

        [SetUp]
        public void SetUp()
        {
            mailbox = new Mailbox(); //в методе создается почтовый ящик
        }
    }
