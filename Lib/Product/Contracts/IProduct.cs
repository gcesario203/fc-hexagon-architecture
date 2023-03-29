using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Product.Contracts
{
    public interface IProduct
    {
        bool IsValid();

        void Enable();

        void Disable();

        string GetId();

        string GetName();

        string GetStatus();

        decimal GetPrice();
    }
}