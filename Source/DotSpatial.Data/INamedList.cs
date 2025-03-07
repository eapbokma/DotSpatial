// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

namespace DotSpatial.Data
{
    /// <summary>
    /// Interface for NamedList.
    /// </summary>
    public interface INamedList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the base name to use for naming items.
        /// </summary>
        string BaseName { get; set; }

        /// <summary>
        /// Gets the count of the items in the list.
        /// </summary>
        int Count { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Re-orders the list so that the index of the specifeid item is lower,
        /// and threfore will be drawn earlier, and therefore should appear
        /// in a lower position on the list.
        /// </summary>
        /// <param name="name">The name of the item to demote.</param>
        void Demote(string name);

        /// <summary>
        /// Gets the item with the specified name as an object.
        /// This enables the INamedList to work with items even if it doesn't know the strong type.
        /// </summary>
        /// <param name="name">The string name of the item to retrieve.</param>
        /// <returns>The actual item cast as an object.</returns>
        object GetItem(string name);

        /// <summary>
        /// Gets the name of the specified item, even if the strong type of the
        /// item is not known.
        /// </summary>
        /// <param name="item">The item to get the name of cast as an object.</param>
        /// <returns>The string name of the specified object.</returns>
        string GetNameOfObject(object item);

        /// <summary>
        /// Gets the list of names for the items currently stored in the list,
        /// in the sequence defined by the list of items.
        /// </summary>
        /// <returns>The names.</returns>
        string[] GetNames();

        /// <summary>
        /// Re-orders the list so that the index of the specified item is higher,
        /// and therefore will be drawn later, and therefore should appear
        /// in a higher position on the list.
        /// </summary>
        /// <param name="name">Name of the item that gets promoted.</param>
        void Promote(string name);

        /// <summary>
        /// Updates the names to match the current set of actual items.
        /// </summary>
        void RefreshNames();

        /// <summary>
        /// Removes the item with the specified name from the list.
        /// </summary>
        /// <param name="name">The string name of the item to remove.</param>
        void Remove(string name);

        #endregion
    }
}