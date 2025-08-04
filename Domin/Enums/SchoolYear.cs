using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Enums
{
    public enum SchoolYear
    {
        [EnumMember(Value = "First Primary")]
        fristprimary = 1,
        [EnumMember(Value = "Second Primary")]
        secondprimary = 2,
        [EnumMember(Value = "Third Primary")]
        thirdprimary = 3,
        [EnumMember(Value = "Fourth Primary")]
        fourthprimary = 4,
        [EnumMember(Value = "Fifth Primary")]
        fifthprimary = 5,
        [EnumMember(Value = "Sixth Primary")]
        sixthprimary = 6,
        [EnumMember(Value = "First Preparatory")]
        fristpreparatory = 7,
        [EnumMember(Value = "Second Preparatory")]
        secondpreparatory = 8,
        [EnumMember(Value = "Third Preparatory")]
        thirdpreparatory = 9,
        [EnumMember(Value = "First Secondary")]
        fristsecondary = 10,
        [EnumMember(Value = "Second Secondary")]
        secondsecondary = 11,
        [EnumMember(Value = "Third Secondary")]
        thirdsecondary = 12,
    }
}
