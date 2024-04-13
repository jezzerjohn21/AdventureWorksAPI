﻿using System;
using System.Collections.Generic;

namespace AdventureWorkPersistence.Models;

/// <summary>
/// Source of the ID that connects vendors, customers, and employees with address and contact information.
/// </summary>
public partial class BusinessEntity
{
    /// <summary>
    /// Primary key for all customers, vendors, and employees.
    /// </summary>
    public int BusinessEntityID { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; } = new List<BusinessEntityAddress>();

    public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; } = new List<BusinessEntityContact>();

    public virtual Person? Person { get; set; }

    public virtual Store? Store { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
