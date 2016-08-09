using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DZ.Linqpad.Utils;

namespace DZ.Linqpad.Utils.Tests
{
    [TestFixture]
    public class ReplaceByRegexTests
    {
        [Test]
        public void CanReplaceWithGroupNumber()
        {
            Assert.That(
                "ok lets <test 123> it quickly $34"
                .ReplaceByRegex(@"<(\w+) (\d+)>", "$2$1")
                .ReplaceByRegex(@"\$(?<test>\d+)", "${test}"),
                Is.EqualTo("ok lets 123test it quickly 34"));
        }

    }
}
