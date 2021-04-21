using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    /// <summary>
    /// Tenant class that holds information about tenant with an api key that is used to to retrive tenant
    /// </summary>
    public class Tenant : BaseEntity
    {
        public string ApiKey { set; get; }

        public string Name { set; get; }

        public bool IsActive { set; get; }

        public string DatabaseConnectionString { set; get; }
    }
}