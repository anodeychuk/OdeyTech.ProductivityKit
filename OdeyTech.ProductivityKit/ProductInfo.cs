// --------------------------------------------------------------------------
// <copyright file="ProductInfo.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Reflection;

namespace OdeyTech.ProductivityKit
{
    /// <summary>
    /// Provides information about a product's assembly, such as copyright, application name, description, and version.
    /// </summary>
    public class ProductInfo
    {
        private readonly Assembly assembly;
        private string copyrightInternal;
        private string applicationNameInternal;
        private string applicationDescriptionInternal;
        private string versionInternal;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInfo"/> class with the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to retrieve product information from.</param>
        public ProductInfo(Assembly assembly)
        {
            this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }

        /// <summary>
        /// Gets the copyright information of the product.
        /// </summary>
        public string Copyright
            => this.copyrightInternal ??= GetAttributeValue<AssemblyCopyrightAttribute, string>(
                attr => attr.Copyright,
                string.Empty);

        /// <summary>
        /// Gets the application name of the product.
        /// </summary>
        public string ApplicationName
            => this.applicationNameInternal ??= GetAttributeValue<AssemblyProductAttribute, string>(
                attr => attr.Product,
                string.Empty);

        /// <summary>
        /// Gets the application description of the product.
        /// </summary>
        public string ApplicationDescription
            => this.applicationDescriptionInternal ??= GetAttributeValue<AssemblyDescriptionAttribute, string>(
                attr => attr.Description,
                string.Empty);

        /// <summary>
        /// Gets the version of the product.
        /// </summary>
        public string Version => this.versionInternal ??= (this.assembly.GetName().Version?.ToString() ?? "Unknown");

        /// <summary>
        /// Retrieves the attribute value from the assembly using the provided selector function.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute to retrieve.</typeparam>
        /// <typeparam name="TResult">The type of the result to return.</typeparam>
        /// <param name="selector">The function to select the desired value from the attribute.</param>
        /// <param name="defaultValue">The default value to return if the attribute is not found.</param>
        /// <returns>The selected value from the attribute, or the default value if the attribute is not found.</returns>
        private TResult GetAttributeValue<TAttribute, TResult>(Func<TAttribute, TResult> selector, TResult defaultValue)
            where TAttribute : Attribute
        {
            var attributes = this.assembly.GetCustomAttributes(typeof(TAttribute), true);
            return attributes.Length > 0 ? selector((TAttribute)attributes[0]) : defaultValue;
        }
    }
}
