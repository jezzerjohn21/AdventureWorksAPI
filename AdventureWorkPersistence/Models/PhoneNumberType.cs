﻿using System;
using System.Collections.Generic;

namespace AdventureWorkPersistence.Models;

/// <summary>
/// Type of phone number of a person.
/// </summary>
public partial class PhoneNumberType
{
    /// <summary>
    /// Primary key for telephone number type records.
    /// </summary>
    public int PhoneNumberTypeID { get; set; }

    /// <summary>
    /// Name of the telephone number type
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PersonPhone> PersonPhone { get; set; } = new List<PersonPhone>();
}
