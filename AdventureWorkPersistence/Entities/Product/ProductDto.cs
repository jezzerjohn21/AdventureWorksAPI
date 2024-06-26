﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorkPersistence.Entities.Product
{
	public class ProductDto
	{
		[Key]
		/// <summary>
		/// Primary key for Product records.
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Name of the product.
		/// </summary>
		public string ProductName { get; set; } = null!;

		/// <summary>
		/// Unique product identification number.
		/// </summary>
		public string ProductNumber { get; set; } = null!;

		/// <summary>
		/// Product color.
		/// </summary>
		public string? Color { get; set; }

		/// <summary>
		/// Selling price.
		/// </summary>
		public decimal ListPrice { get; set; }


		/*
		This is for query child tables
		introduce subcategory
		*/
		public string? ProductSubCategoryName { get; set; }

		public string? ProductCategoryName { get; set; }
	}

		public class ProductDTOMapper : Profile 
		{
		public ProductDTOMapper()
		{

			/*	CreateMap<ProductDto, Models.Product>()
					.ForMember(s => s.ProductID, d => d.MapFrom(x => x.ID))
					.ForMember(s => s.Name, d => d.MapFrom(x => x.ProductName))
					.ReverseMap();*/

			/*
			This is for query child tables
			introduce subcategory
			*/

			CreateMap<Models.Product, ProductDto>()
			.ForMember(s => s.ID, d => d.MapFrom(x => x.ProductID))
			.ForMember(s => s.ProductName, d => d.MapFrom(x => x.Name))
			.ForMember(s => s.ProductSubCategoryName, d => d.MapFrom(x => x.ProductSubcategory == null ? null : x.ProductSubcategory.Name))
			.ForMember(s => s.ProductCategoryName,
			d => d.MapFrom(x => x.ProductSubcategory == null ? null : x.ProductSubcategory.ProductCategory == null ? null : x.ProductSubcategory.ProductCategory.Name));
			}
		}
	}
	