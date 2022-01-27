﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace DapperPerfTest.EFCore6.Scaffold
{
    internal partial class ProductEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "DapperPerfTest.EFCore6.Scaffold.Product",
                typeof(Product),
                baseEntityType);

            var productId = runtimeEntityType.AddProperty(
                "ProductId",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("ProductId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            productId.AddAnnotation("Relational:ColumnName", "ProductID");
            productId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var categoryId = runtimeEntityType.AddProperty(
                "CategoryId",
                typeof(int?),
                propertyInfo: typeof(Product).GetProperty("CategoryId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<CategoryId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            categoryId.AddAnnotation("Relational:ColumnName", "CategoryID");
            categoryId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var discontinued = runtimeEntityType.AddProperty(
                "Discontinued",
                typeof(bool),
                propertyInfo: typeof(Product).GetProperty("Discontinued", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Discontinued>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            discontinued.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var productName = runtimeEntityType.AddProperty(
                "ProductName",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("ProductName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 40);
            productName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var quantityPerUnit = runtimeEntityType.AddProperty(
                "QuantityPerUnit",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("QuantityPerUnit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<QuantityPerUnit>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20);
            quantityPerUnit.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var reorderLevel = runtimeEntityType.AddProperty(
                "ReorderLevel",
                typeof(short?),
                propertyInfo: typeof(Product).GetProperty("ReorderLevel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ReorderLevel>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            reorderLevel.AddAnnotation("Relational:DefaultValueSql", "((0))");
            reorderLevel.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var supplierId = runtimeEntityType.AddProperty(
                "SupplierId",
                typeof(int?),
                propertyInfo: typeof(Product).GetProperty("SupplierId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<SupplierId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            supplierId.AddAnnotation("Relational:ColumnName", "SupplierID");
            supplierId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitPrice = runtimeEntityType.AddProperty(
                "UnitPrice",
                typeof(decimal?),
                propertyInfo: typeof(Product).GetProperty("UnitPrice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<UnitPrice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            unitPrice.AddAnnotation("Relational:ColumnType", "money");
            unitPrice.AddAnnotation("Relational:DefaultValueSql", "((0))");
            unitPrice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitsInStock = runtimeEntityType.AddProperty(
                "UnitsInStock",
                typeof(short?),
                propertyInfo: typeof(Product).GetProperty("UnitsInStock", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<UnitsInStock>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            unitsInStock.AddAnnotation("Relational:DefaultValueSql", "((0))");
            unitsInStock.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitsOnOrder = runtimeEntityType.AddProperty(
                "UnitsOnOrder",
                typeof(short?),
                propertyInfo: typeof(Product).GetProperty("UnitsOnOrder", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<UnitsOnOrder>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            unitsOnOrder.AddAnnotation("Relational:DefaultValueSql", "((0))");
            unitsOnOrder.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { productId });
            runtimeEntityType.SetPrimaryKey(key);

            var categoriesProducts = runtimeEntityType.AddIndex(
                new[] { categoryId },
                name: "CategoriesProducts");

            var categoryID = runtimeEntityType.AddIndex(
                new[] { categoryId },
                name: "CategoryID");

            var productName0 = runtimeEntityType.AddIndex(
                new[] { productName },
                name: "ProductName");

            var supplierID = runtimeEntityType.AddIndex(
                new[] { supplierId },
                name: "SupplierID");

            var suppliersProducts = runtimeEntityType.AddIndex(
                new[] { supplierId },
                name: "SuppliersProducts");

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CategoryId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("CategoryId")! })!,
                principalEntityType);

            var category = declaringEntityType.AddNavigation("Category",
                runtimeForeignKey,
                onDependent: true,
                typeof(Category),
                propertyInfo: typeof(Product).GetProperty("Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Category>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Category).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Category).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Products_Categories");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("SupplierId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("SupplierId")! })!,
                principalEntityType);

            var supplier = declaringEntityType.AddNavigation("Supplier",
                runtimeForeignKey,
                onDependent: true,
                typeof(Supplier),
                propertyInfo: typeof(Product).GetProperty("Supplier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Supplier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Supplier).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Supplier).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Products_Suppliers");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Products");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
