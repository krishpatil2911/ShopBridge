using Data.IRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Mocks
{
    public class MockGenericRepository<T> : Mock<IGenericRepository<T>> where T:class
    {
    }
}
