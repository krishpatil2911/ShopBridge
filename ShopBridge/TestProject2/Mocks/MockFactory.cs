using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Mocks
{
    public class MockFactory
    {
        private IDictionary<Type, Mock> _mocksContainer;
        public MockFactory()
        {
            _mocksContainer = new Dictionary<Type, Mock>();
        }

        public TMock Get<TMock>() where TMock : Mock , new()
        {
            var type = typeof(TMock);
            if (_mocksContainer.ContainsKey(type))
            {
                return (TMock)_mocksContainer[type];
            }
            var tmock = new TMock();
            _mocksContainer.Add(type, tmock);
            return tmock;
        }
    }
}
