using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RemoveDuplicates.FromArrays {
	
	[TestFixture]
	class TwoStringArraysTests {
		
		/// <summary>
		/// Runs tests against all implementations
		/// </summary>
		/// <param name="arrayA">Test data.</param>
		/// <param name="arrayB">Test data.</param>
		/// <param name="expectedOutput">Expected output.</param>
		private void RunTests(
			string[] arrayA,
			string[] arrayB,
			string[] expectedOutput
		) { 
			CollectionAssert.AreEquivalent(
				expectedOutput,
				TwoStringArrays.BruteForce(
					arrayA,
					arrayB
				),
				"Test failed when using BruteForce"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				TwoStringArrays.SortAndRemove(
					arrayA,
					arrayB
				),
				"Test failed when using SortAndRemove"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				TwoStringArrays.WithHashSet(
					arrayA,
					arrayB
				),
				"Test failed when using WithSet"
			);
		}

		[Test]
		public void TwoEmptyArrays() {
			string[] arrayA = new string[0];
			string[] arrayB = new string[0];

			string[] expectedOutput = new string[0];

			RunTests(
				arrayA,
				arrayB,
				expectedOutput
			);
		}

		[Test]
		public void NoDuplicates() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"watermelon"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			string[] expectedOutput = new string[7] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			RunTests(
				arrayA,
				arrayB,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesInFirstArray() {
			string[] arrayA = new string[3] {
				"watermelon",
				"avocado",
				"watermelon"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			string[] expectedOutput = new string[6] {
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			RunTests(
				arrayA,
				arrayB,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesInSecondArray() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"watermelon"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"charmander",
				"pikachu"
			};

			string[] expectedOutput = new string[6] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"pikachu"
			};

			RunTests(
				arrayA,
				arrayB,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesAcrossArrays() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"mewtwo"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			string[] expectedOutput = new string[6] {
				"mango",
				"avocado",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			RunTests(
				arrayA,
				arrayB,
				expectedOutput
			);
		}
	}
}
