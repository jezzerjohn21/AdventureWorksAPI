﻿using System;
using System.Collections.Generic;

namespace AdventureWorkPersistence.Models;

public partial class vSalesPerson
{
    public int BusinessEntityID { get; set; }

    public string? Title { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Suffix { get; set; }

    public string JobTitle { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? PhoneNumberType { get; set; }

    public string? EmailAddress { get; set; }

    public int EmailPromotion { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string StateProvinceName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string CountryRegionName { get; set; } = null!;

    public string? TerritoryName { get; set; }

    public string? TerritoryGroup { get; set; }

    public decimal? SalesQuota { get; set; }

    public decimal SalesYTD { get; set; }

    public decimal SalesLastYear { get; set; }
}
