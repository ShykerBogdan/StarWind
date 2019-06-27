using System;
using System.Collections.Generic;
using System.Text;

namespace TestCommon
{
  public  interface IPlugin
    {
        Client GetClient(int id);

        void UpdateClient(Client client);
    }
}
