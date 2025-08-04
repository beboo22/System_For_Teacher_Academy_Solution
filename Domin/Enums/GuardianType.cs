using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Enums
{
    public enum GuardianType
    {
        [EnumMember(Value = "Father")]
        Father = 1,
        [EnumMember(Value = "Mother")]
        Mother = 2,
        [EnumMember(Value = "GrandFather")]
        GrandFather = 3,
        [EnumMember(Value = "GrandMother")]
        GrandMother = 4,
        [EnumMember(Value = "Uncle")]
        Uncle = 5,
        [EnumMember(Value = "Aunt")]
        Aunt = 6,
        [EnumMember(Value = "Brother")]
        Brother = 7,
        [EnumMember(Value = "Sister")]
        Sister = 8,
        [EnumMember(Value = "Other")]
        Other = 9
    }
}
