﻿using System;
using System.Collections.Generic;

namespace AdventureWorkPersistence.Models;

public partial class vStoreWithAddresses
{
    public int BusinessEntityID { get; set; }

    public string Name { get; set; } = null!;

    public string AddressType { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string StateProvinceName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string CountryRegionName { get; set; } = null!;
}
