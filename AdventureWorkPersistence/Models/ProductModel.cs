﻿using System;
using System.Collections.Generic;

namespace AdventureWorkPersistence.Models;

/// <summary>
/// Product model classification.
/// </summary>
public partial class ProductModel
{
    /// <summary>
    /// Primary key for ProductModel records.
    /// </summary>
    public int ProductModelID { get; set; }

    /// <summary>
    /// Product model description.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Detailed product catalog information in xml format.
    /// </summary>
    public string? CatalogDescription { get; set; }

    /// <summary>
    /// Manufacturing instructions in xml format.
    /// </summary>
    public string? Instructions { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Product> Product { get; set; } = new List<Product>();

    public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; } = new List<ProductModelIllustration>();

    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; } = new List<ProductModelProductDescriptionCulture>();
}