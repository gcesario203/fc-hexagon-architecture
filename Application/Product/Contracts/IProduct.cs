using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared.Abstractions;

namespace Application.Product.Contracts
{
    public interface IProduct
    {
        void Enable();

        void Disable();

        string GetId();

        string GetName();

        string GetStatus();

        decimal GetPrice();

        (bool isValid, Exception? exception) IsValid();
    }
}