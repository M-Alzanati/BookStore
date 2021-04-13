using System;
using System.Collections.Generic;

namespace BookStore.Core.DTO
{
    public class TenantMapping
    {
        public string Default { set; get; }

        public Dictionary<string, string> Tenants { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }
}