﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

namespace Microsoft.ML
{
    /// <summary>
    /// Extension methods for the <see cref="TransformsCatalog"/>.
    /// </summary>
    public static class TransformExtensionsCatalog
    {
        /// <summary>
        /// Copies the input column to another column named as specified in <paramref name="outputColumnName"/>.
        /// </summary>
        /// <param name="catalog">The transform's catalog.</param>
        /// <param name="outputColumnName">Name of the column resulting from the transformation of <paramref name="inputColumnName"/>.</param>
        /// <param name="inputColumnName">Name of the columns to transform.</param>
        public static ColumnCopyingEstimator CopyColumns(this TransformsCatalog catalog, string outputColumnName, string inputColumnName)
            => new ColumnCopyingEstimator(CatalogUtils.GetEnvironment(catalog), outputColumnName, inputColumnName);

        /// <summary>
        /// Copies the input column, name specified in the first item of the tuple,
        /// to another column, named as specified in the second item of the tuple.
        /// </summary>
        /// <param name="catalog">The transform's catalog</param>
        /// <param name="columns">The pairs of input and output columns.</param>
        public static ColumnCopyingEstimator CopyColumns(this TransformsCatalog catalog, params (string outputColumnName, string inputColumnName)[] columns)
            => new ColumnCopyingEstimator(CatalogUtils.GetEnvironment(catalog), columns);

        /// <summary>
        /// Concatenates two columns together.
        /// </summary>
        /// <param name="catalog">The transform's catalog.</param>
        /// <param name="outputColumnName">Name of the column resulting from the transformation of <paramref name="inputColumnNames"/>.</param>
        /// <param name="inputColumnNames">Name of the columns to transform.</param>
        public static ColumnConcatenatingEstimator Concatenate(this TransformsCatalog catalog, string outputColumnName, params string[] inputColumnNames)
            => new ColumnConcatenatingEstimator(CatalogUtils.GetEnvironment(catalog), outputColumnName, inputColumnNames);

        /// <summary>
        /// DropColumns is used to select a list of columns that user wants to drop from a given input. Any column not specified will
        /// be maintained in the output schema.
        /// </summary>
        /// <param name="catalog">The transform's catalog.</param>
        /// <param name="columnsToDrop">The array of column names to drop.</param>
        public static ColumnSelectingEstimator DropColumns(this TransformsCatalog catalog, params string[] columnsToDrop)
            => ColumnSelectingEstimator.DropColumns(CatalogUtils.GetEnvironment(catalog), columnsToDrop);

        /// <summary>
        /// ColumnSelectingEstimator is used to select a list of columns that user wants to drop from a given input.
        /// </summary>
        /// <param name="catalog">The transform's catalog.</param>
        /// <param name="keepColumns">The array of column names to keep.</param>
        /// <param name="keepHidden">If true will keep hidden columns and false will remove hidden columns.</param>
        public static ColumnSelectingEstimator SelectColumns(this TransformsCatalog catalog,
            string[] keepColumns,
            bool keepHidden = ColumnSelectingTransformer.Defaults.KeepHidden)
            => new ColumnSelectingEstimator(CatalogUtils.GetEnvironment(catalog),
                keepColumns, null, keepHidden, ColumnSelectingTransformer.Defaults.IgnoreMissing);
    }
}
