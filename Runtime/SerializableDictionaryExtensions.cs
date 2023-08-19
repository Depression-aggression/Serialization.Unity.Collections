﻿// Copyright © 2022-2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Serialization.Collections.Runtime
{
	internal static class SerializableDictionaryExtensions
	{
		/// <summary>
		/// Attempts to retrieve a value from a key.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="key">The key to search in the <seealso cref="SerializableDictionary{TKey,TValue}"/> with.</param>
		/// <returns>If the key doesn't exist or the value is null a NullReferenceException will be raised.</returns>
		public static TValue GetValue<TKey, TValue>(this SerializableDictionary<TKey, TValue> self, TKey key)
		{
			self.TryGetValue(key, out var defaultValue);
			return defaultValue!.Value;
		}

		/// <summary>
		/// Attempts to retrieve a value from a key, passing out the ref to the value provided.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="key">The key to search in the <seealso cref="SerializableDictionary{TKey,TValue}"/> with.</param>
		/// <param name="value">The desired value to retrieve. If it returns false, the value returned will be null.</param>
		/// <returns>The bool will return true if it successfully retrieves the value from the key provided.</returns>
		public static bool TryGetValue<TKey, TValue>(this SerializableDictionary<TKey, TValue> self,
			TKey key, ref TValue value)
		{
			var canGet = self.TryGetValue(key, out var defaultValue);
			if (defaultValue != null)
			{
				value = defaultValue.Value;
			}

			return canGet;
		}
	}
}