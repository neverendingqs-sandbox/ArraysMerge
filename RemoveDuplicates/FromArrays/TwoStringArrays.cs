using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates.FromArrays
{
	/// <summary>
	/// Removes any duplicate string values between two arrays.
	/// </summary>
	public class TwoStringArrays
	{
		/// <summary>
		/// Concatenates the two arrays, then iterates through the concatenated array.
		/// Each element is added to the output list only if the element does not exist in the output.
		/// In each iteration, the element is compared to all elements in the output list.
		/// to determine if it contains a unique value.
		/// Runs in O((n+m)^2) time, where:
		///		n is the total number of strings in the first array
		///		m is the total number of strings in the second array
		/// </summary>
		/// <param name="arrayA">An array of strings.</param>
		/// <param name="arrayB">Another array of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] BruteForce(
			string[] arrayA,
			string[] arrayB
		) {
			List<string> output = new List<string>();
			string[] combinedArray = ConcatenateStringArrays(
				arrayA,
				arrayB
			);

			for (int i = 0; i < combinedArray.Length; i++) {
				if (combinedArray[i] == null) {
					continue;
				}
				
				for( int j = i + 1; j < combinedArray.Length; j++ ) {
					if( combinedArray[i] == combinedArray[j] ) {
						combinedArray[j] = null;
					}
				}

				output.Add( combinedArray[i] );
			}

			return output.ToArray();
		}

		/// <summary>
		/// Concatenates two arrays, sorts them, and removes any duplicates.
		/// Runs in O(mnlog(mn)) time, where:
		///		n is the total number of strings in the first array
		///		m is the total number of strings in the second array
		/// </summary>
		/// <param name="arrayA">An array of strings.</param>
		/// <param name="arrayB">Another array of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] SortAndRemove(
			string[] arrayA,
			string[] arrayB
		) {
			string[] combinedArray = ConcatenateStringArrays(
				arrayA,
				arrayB
			);

			Array.Sort( combinedArray );

			for( int i = 1; i < combinedArray.Length; i++ ) {
				if( combinedArray[i] == combinedArray[i - 1] ) {
					combinedArray[i] = null;
				}
			}

			List<string> output = new List<string>();
			foreach( string item in combinedArray ) {
				if( item != null ) {
					output.Add( item );
				}
			}

			return output.ToArray();
		}

		/// <summary>
		/// Adds all strings into a hash set to remove any duplicates.
		/// Runs in O(h(m+n)) time, where:
		///		n is the total number of strings in the first array
		///		m is the total number of strings in the second array
		///		h is the runtime of the hash function.
		/// </summary>
		/// <param name="arrayA">An array of strings.</param>
		/// <param name="arrayB">Another array of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] WithHashSet(
			string[] arrayA,
			string[] arrayB
		) {
			HashSet<string> output = new HashSet<string>();

			foreach (string item in arrayA) {
				output.Add(item);
			}

			foreach (string item in arrayB) {
				output.Add(item);
			}

			return output.ToArray();
		}

		private static string[] ConcatenateStringArrays(
			string[] arrayA,
			string[] arrayB
		) {
			string[] combinedArray = new string[arrayA.Length + arrayB.Length];

			arrayA.CopyTo( combinedArray, 0 );
			arrayB.CopyTo( combinedArray, arrayA.Length );

			return combinedArray;
		}
	}
}
