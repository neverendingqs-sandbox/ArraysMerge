using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates.FromArrays {
	
	/// <summary>
	/// Removes any duplicates among N arrays
	/// </summary>
	public class MultipleStringArrays {

		/// <summary>
		/// Concatenates all the arrays, then iterates through the concatenated array.
		/// Each element is added to the output list only if the element does not exist in the output.
		/// In each iteration, the element is compared to all elements in the output list.
		/// to determine if it contains a unique value.
		/// Runs in O((nm)^2) time, where:
		///		n is the number of arrays
		///		m is the number of words in the largest array
		/// </summary>
		/// <param name="arrays">Arrays of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] BruteForce(
			List<string[]> arrays
		) {
			string[] combinedArray = CombineArrays(
				arrays
			);
			List<string> output = new List<string>();

			for( int i = 0; i < combinedArray.Length; i++ ) {
				if( combinedArray[i] == null ) {
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
		/// Concatenates all the arrays, sorts them, and removes any duplicates.
		/// Runs in O(mnlog(mn)) time, where:
		///		n is the number of arrays
		///		m is the number of words in the largest array
		/// </summary>
		/// <param name="arrays">Arrays of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] CombineAndSort(
			List<string[]> arrays
		) {
			List<string> combinedList = new List<string>();

			foreach( string[] array in arrays ) {
				foreach( string item in array ) {
					combinedList.Add( item );
				}
			}

			if( combinedList.Count == 0 ) {
				return new string[0];
			}

			string[] combinedArray = combinedList.ToArray();
			Array.Sort( combinedArray );

			string currWord = combinedArray[0];
			List<string> output = new List<string>();
			output.Add( currWord );
			for( int i = 1; i < combinedArray.Length; i++ ) {
				if( combinedArray[i] == currWord ) {
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
		/// <param name="arrays">Arrays of strings.</param>
		/// <returns>An array of unique strings.</returns>
		public static string[] UseHashSet(
			List<string[]> arrays
		) {
			HashSet<string> output = new HashSet<string>();

			foreach( string[] array in arrays ) {
				foreach( string item in array ) {
					output.Add( item );
				}
			}

			return output.ToArray();
		}

		private static string[] CombineArrays (
			List<string[]> arrays
		) {
			List<string> combinedList = new List<string>();

			foreach( string[] array in arrays ) {
				foreach( string item in array ) {
					combinedList.Add( item );
				}
			}

			return combinedList.ToArray();
		}
	}
}
