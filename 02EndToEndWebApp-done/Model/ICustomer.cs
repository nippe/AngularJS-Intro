using System;
namespace _02EndToEndWebApp_done.Model
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        string Name { get; set; }
        string StreetAddress { get; set; }
    }
}
