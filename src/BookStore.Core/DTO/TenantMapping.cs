using System;
using System.Collections.Generic;

namespace BookStore.Core.DTO
{
    /// <summary>
    /// Represent a memory object of tenants mapping in application.json
    /// </summary>
    public class TenantMapping
    {
        public string Default { set; get; }

        public Dictionary<string, string> Tenants { get; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }
}