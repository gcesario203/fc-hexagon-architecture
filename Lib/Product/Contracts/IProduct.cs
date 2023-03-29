using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Shared.Abstractions;

namespace Lib.Product.Contracts
{
    public interface IProduct
    {
        void Enable();

        void Disable();

        string GetId();

        string GetName();

        string GetStatus();

        decimal GetPrice();
    }
}