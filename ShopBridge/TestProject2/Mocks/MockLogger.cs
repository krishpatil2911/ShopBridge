using Moq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Mocks
{
    public class MockLogger<T> : Mock<ILogger<T>>
    {
    }
}
