using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Custom
    {
        uint Id { set; get; }
        public string Name { set; get; }
        public Custom(uint id,string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"客户Id:{Id} 客户姓名:{Name}";
        }
    }
}
