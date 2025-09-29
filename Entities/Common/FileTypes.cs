using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;

namespace Entities.Common
{
    public enum FileTypes
    {
        [Display(Name="E")]
        [Description("E")]
        BLKOPE = 1,

        [Description("U")]
        BLKOPU = 2,

        [Description("M")]
        BLKOPM = 3,

        [Description("N")]
        BLKOPN = 4,

        [Description("BA")]
        BLKOPBA = 5,

        [Description("BR")]
        BLKOPBR = 6,

        [Description("BB")]
        BLKOPBB = 7,

        [Description("BU")]
        BLKOPBU = 8,

        [Description("IA")]
        BLKOPIA = 9,

        [Description("E")]
        BLKOPP2BE = 10,

        [Description("U")]
        BLKOPP2BU = 11,

        [Description("AB")]
        BLKOPP2BAB = 12,

        [Description("DF")]
        BLKOPP2BDF = 13,

        [Description("RB")]
        BLKOPP2BRB = 14,

        [Description("SI")]
        BLKOPP2BSI = 15,

        [Description("DI")]
        BLKOPP2BDI = 16,

        [Description("A")]
        BLKOPP2BA = 17,

        [Description("N")]
        BLKOPP2BN = 18,

        [Description("CD")]
        BLKOPP2BCD = 19,

        [Description("C")]
        BLKOPP2BC = 20,

        [Description("MC")]
        BLKOPP2BMC = 21,
    }
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType != typeof(string))
            {
                if (property.PropertyType.GetInterface(nameof(IEnumerable)) != null)
                    property.ShouldSerialize =
                        instance => (instance?.GetType().GetProperty(property.PropertyName).GetValue(instance) as IEnumerable<object>)?.Count() > 0;
            }
            return property;
        }
    }
}
