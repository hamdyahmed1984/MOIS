using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class RequestHelper
    {
        public static RequesterName BuildRequesterName(string firstName, string fatherName, string grandFatherName, string familyName)
        => new RequesterName(firstName, fatherName, grandFatherName, familyName);
    }
}
