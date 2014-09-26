using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RemoveDuplicates.FromArrays {
	[TestFixture]
	class MultipleStringArraysTests {

		/// <summary>
		/// Runs tests against all implementations.
		/// </summary>
		/// <param name="arrays">Test data.</param>
		/// <param name="expectedOutput">Expected output.</param>
		private void RunTests(
			List<string[]> arrays,
			string[] expectedOutput
		) {
			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleStringArrays.BruteForce(
					arrays
				),
				"Test failed when using BruteForce"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleStringArrays.CombineAndSort(
					arrays
				),
				"Test failed when using CombineAndSort"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleStringArrays.UseHashSet(
					arrays
				),
				"Test failed when using UseHashSet"
			);
		}

		[Test]
		public void EmptyArrays() {
			List<string[]> arrays = new List<string[]> {
				new string[0],
				new string[0],
				new string[0]
			};

			string[] expectedOutput = new string[0];

			RunTests(
				arrays,
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

			string[] arrayC = new string[3] {
				"Enoch",
				"Rachel",
				"John"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[10] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu",
				"Enoch",
				"Rachel",
				"John"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInFirstArray() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"mango"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu"
			};

			string[] arrayC = new string[3] {
				"Enoch",
				"Rachel",
				"John"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[9] {
				"mango",
				"avocado",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu",
				"Enoch",
				"Rachel",
				"John"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInSecondArray() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"watermelon"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"weedle",
				"pikachu"
			};

			string[] arrayC = new string[3] {
				"Enoch",
				"Rachel",
				"John"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[9] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"pikachu",
				"Enoch",
				"Rachel",
				"John"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInThirdArray() {
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

			string[] arrayC = new string[3] {
				"Enoch",
				"Enoch",
				"John"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[9] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu",
				"Enoch",
				"John"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInTwoArrays() {
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

			string[] arrayC = new string[3] {
				"Enoch",
				"watermelon",
				"John"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[9] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"mewtwo",
				"pikachu",
				"Enoch",
				"John"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesAcrossArrays() {
			string[] arrayA = new string[3] {
				"mango",
				"avocado",
				"watermelon"
			};

			string[] arrayB = new string[4] {
				"charmander",
				"weedle",
				"watermelon",
				"pikachu"
			};

			string[] arrayC = new string[3] {
				"Enoch",
				"Rachel",
				"watermelon"
			};

			List<string[]> arrays = new List<string[]> {
				arrayA,
				arrayB,
				arrayC
			};

			string[] expectedOutput = new string[8] {
				"mango",
				"avocado",
				"watermelon",
				"charmander",
				"weedle",
				"pikachu",
				"Enoch",
				"Rachel"
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}
	}
}
