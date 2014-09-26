using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates.FromArrays {
	
	/// <summary>
	/// Removes any duplicates among N arrays
	/// </summary>
	public class MultipleArrays {

		/// <summary>
		/// Concatenates all the arrays, then iterates through the concatenated array.
		/// Each element is added to the output list only if the element does not exist in the output.
		/// In each iteration, the element is compared to all elements in the output list.
		/// to determine if it contains a unique value.
		/// Runs in O((nm)^2) time, where:
		///		n is the number of arrays
		///		m is the number of elements in the largest array
		/// </summary>
		/// <param name="arrays">Arrays of objects.</param>
		/// <returns>An array of unique objects.</returns>
		public static T[] BruteForce<T>(
			List<T[]> arrays
		) where T : IEquatable<T> {
			T[] combinedArray = CombineArrays<T>(
				arrays
			);

			List<T> output = new List<T>();

			for( int i = 0; i < combinedArray.Length; i++ ) {
				if( output.Contains( combinedArray[i] )
				) {
					continue;
				}

				output.Add( combinedArray[i] );
			}

			return output.ToArray();
		}

		/// <summary>
		/// Concatenates all the arrays, sorts them, and removes any duplicates.
		/// Runs in O(mnlog(mn)) time, where:
		///		n is the number of arrays
		///		m is the number of words in the largest array
		/// </summary>
		/// <param name="arrays">Arrays of objects.</param>
		/// <returns>An array of unique objects.</returns>
		public static T[] CombineAndSort<T>(
			List<T[]> arrays
		) where T : IComparable {
			List<T> combinedList = new List<T>();

			foreach( T[] array in arrays ) {
				foreach( T item in array ) {
					combinedList.Add( item );
				}
			}

			if( combinedList.Count == 0 ) {
				return new T[0];
			}

			T[] combinedArray = combinedList.ToArray();
			Array.Sort( combinedArray );

			T currWord = combinedArray[0];
			List<T> output = new List<T>();
			output.Add( currWord );
			for( int i = 1; i < combinedArray.Length; i++ ) {
				if( combinedArray[i].CompareTo(currWord) == 0) {
					continue;
				}

				currWord = combinedArray[i];
				output.Add( currWord );
			}
			
			return output.ToArray();
		}

		/// <summary>
		/// Adds all strings into a hash set to remove any duplicates.
		/// Runs in O(h(m+n)) time, where:
		///		n is the number of arrays
		///		m is the number of words in the largest array
		///		h is the runtime of the hash function.
		/// </summary>
		/// <param name="arrays">Arrays of objects.</param>
		/// <returns>An array of unique objects.</returns>
		public static T[] UseHashSet<T>(
			List<T[]> arrays
		) {
			HashSet<T> output = new HashSet<T>();

			foreach( T[] array in arrays ) {
				foreach( T item in array ) {
					output.Add( item );
				}
			}

			return output.ToArray();
		}

		private static T[] CombineArrays<T>(
			List<T[]> arrays
		) {
			List<T> combinedList = new List<T>();

			foreach( T[] array in arrays ) {
				foreach( T item in array ) {
					combinedList.Add( item );
				}
			}

			return combinedList.ToArray();
		}
	}
}
