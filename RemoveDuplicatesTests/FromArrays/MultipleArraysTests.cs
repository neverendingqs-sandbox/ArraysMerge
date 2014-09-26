using DataStructures.XYCoordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace RemoveDuplicates.FromArrays {
	
	[TestFixture]
	class MultipleArraysUsingStringsTests {

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
				MultipleArrays.BruteForce(
					arrays
				),
				"Test failed when using BruteForce"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.CombineAndSort(
					arrays
				),
				"Test failed when using CombineAndSort"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.UseHashSet(
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

	[TestFixture]
	class MultipleArraysUsingNodesTests {
		private Node[] nodes;

		/// <summary>
		/// Runs tests against all implementations.
		/// </summary>
		/// <param name="arrays">Test data.</param>
		/// <param name="expectedOutput">Expected output.</param>
		private void RunTests(
			List<Node[]> arrays,
			Node[] expectedOutput
		) {
			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.BruteForce(
					arrays
				),
				"Test failed when using BruteForce"
			);

			// Skipping CombineAndSort because Nodes do not implement IComparable

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.UseHashSet(
					arrays
				),
				"Test failed when using UseHashSet"
			);
		}

		[SetUp]
		public void Setup() {
			nodes = new Node[10] {
				new Node {
					x = 1,
					y = 2
				},
				new Node {
					x = 1,
					y = -2
				},
				new Node {
					x = -1,
					y = 2
				},
				new Node {
					x = -1,
					y = -2
				},
				new Node {
					x = 5,
					y = 17
				},
				new Node {
					x = -4,
					y = 11
				},
				new Node {
					x = -99,
					y = 12
				},
				new Node {
					x = -9,
					y = 132
				},
				new Node {
					x = 5,
					y = 2
				},
				new Node {
					x = 12,
					y = 25
				}
			};
		}

		[Test]
		public void EmptyArrays() {
			List<Node[]> arrays = new List<Node[]> {
				new Node[0],
				new Node[0],
				new Node[0]
			};

			Node[] expectedOutput = new Node[0];

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void NoDuplicates() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[2]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[8],
				nodes[9]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			Node[] expectedOutput = nodes;

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInFirstArray() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[0]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[8],
				nodes[9]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Node[] expectedOutput = new Node[9] {
				nodes[0],
				nodes[1],
				// nodes[2], has been replaced by nodes[0]
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6],
				nodes[7],
				nodes[8],
				nodes[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInSecondArray() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[2]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[4],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[8],
				nodes[9]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Node[] expectedOutput = new Node[9] {
				nodes[0],
				nodes[1],
				nodes[2],
				nodes[3],
				nodes[4],
				// nodes[5], has been replaced by nodes[4]
				nodes[6],
				nodes[7],
				nodes[8],
				nodes[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInThirdArray() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[2]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[7],
				nodes[9]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Node[] expectedOutput = new Node[9] {
				nodes[0],
				nodes[1],
				nodes[2],
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6],
				nodes[7],
				// nodes[8], has been replaced by nodes[7]
				nodes[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInTwoArrays() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[2]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[2],
				nodes[9]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Node[] expectedOutput = new Node[9] {
				nodes[0],
				nodes[1],
				nodes[2],
				nodes[3],
				nodes[4],
				nodes[5],
				nodes[6],
				nodes[7],
				// nodes[8], has been replaced by nodes[2]
				nodes[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesAcrossArrays() {
			Node[] arrayA = new Node[3] {
				nodes[0],
				nodes[1],
				nodes[2]
			};

			Node[] arrayB = new Node[4] {
				nodes[3],
				nodes[4],
				nodes[2],
				nodes[6]
			};

			Node[] arrayC = new Node[3] {
				nodes[7],
				nodes[8],
				nodes[2]
			};

			List<Node[]> arrays = new List<Node[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Node[] expectedOutput = new Node[8] {
				nodes[0],
				nodes[1],
				nodes[2],
				nodes[3],
				nodes[4],
				// nodes[5], has been replaced by nodes[2]
				nodes[6],
				nodes[7],
				nodes[8]
				// nodes[9] has been replaced by nodes[2]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}
	}

	[TestFixture]
	class MultipleArraysUsingEdgesTests {
		private Edge[] edges;

		/// <summary>
		/// Runs tests against all implementations.
		/// </summary>
		/// <param name="arrays">Test data.</param>
		/// <param name="expectedOutput">Expected output.</param>
		private void RunTests(
			List<Edge[]> arrays,
			Edge[] expectedOutput
		) {
			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.BruteForce(
					arrays
				),
				"Test failed when using BruteForce"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.CombineAndSort(
					arrays
				),
				"Test failed when using CombineAndSort"
			);

			CollectionAssert.AreEquivalent(
				expectedOutput,
				MultipleArrays.UseHashSet(
					arrays
				),
				"Test failed when using UseHashSet"
			);
		}

		[SetUp]
		public void Setup() {
			Node[] nodes = new Node[4] {
				new Node {
					x = 1,
					y = 2
				},
				new Node {
					x = 1,
					y = -2
				},
				new Node {
					x = -1,
					y = 2
				},
				new Node {
					x = -1,
					y = -2
				}
			};

			List<Edge> edgesList = new List<Edge>();

			for( int i = 0; i < nodes.Count(); i++ ) {
				for( int j = 0; j < nodes.Count(); j++ ) {
					if( i == j ) {
						continue;
					}

					edgesList.Add(
						new Edge {
							StartNode = nodes[i],
							EndNode = nodes[j]
						}
					);
				}
			}

			this.edges = edgesList.ToArray();
		}

		[Test]
		public void EmptyArrays() {
			List<Edge[]> arrays = new List<Edge[]> {
				new Edge[0],
				new Edge[0],
				new Edge[0]
			};

			Edge[] expectedOutput = new Edge[0];

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void NoDuplicates() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[2]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[5],
				edges[6]
			};

			Edge[] arrayC = new Edge[5] {
				edges[7],
				edges[8],
				edges[9],
				edges[10],
				edges[11]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			Edge[] expectedOutput = edges;

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInFirstArray() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[0]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[5],
				edges[6]
			};

			Edge[] arrayC = new Edge[3] {
				edges[7],
				edges[8],
				edges[9]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Edge[] expectedOutput = new Edge[9] {
				edges[0],
				edges[1],
				// edges[2], has been replaced by node[0]
				edges[3],
				edges[4],
				edges[5],
				edges[6],
				edges[7],
				edges[8],
				edges[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInSecondArray() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[2]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[4],
				edges[6]
			};

			Edge[] arrayC = new Edge[3] {
				edges[7],
				edges[8],
				edges[9]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Edge[] expectedOutput = new Edge[9] {
				edges[0],
				edges[1],
				edges[2],
				edges[3],
				edges[4],
				// edges[5], has been replaced by edges[4]
				edges[6],
				edges[7],
				edges[8],
				edges[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInThirdArray() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[2]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[5],
				edges[6]
			};

			Edge[] arrayC = new Edge[3] {
				edges[7],
				edges[7],
				edges[9]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Edge[] expectedOutput = new Edge[9] {
				edges[0],
				edges[1],
				edges[2],
				edges[3],
				edges[4],
				edges[5],
				edges[6],
				edges[7],
				// edges[8], has been replaced by edges[7]
				edges[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicateInTwoArrays() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[2]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[5],
				edges[6]
			};

			Edge[] arrayC = new Edge[3] {
				edges[7],
				edges[2],
				edges[9]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Edge[] expectedOutput = new Edge[9] {
				edges[0],
				edges[1],
				edges[2],
				edges[3],
				edges[4],
				edges[5],
				edges[6],
				edges[7],
				// edges[8], has been replaced by edges[2]
				edges[9]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}

		[Test]
		public void DuplicatesAcrossArrays() {
			Edge[] arrayA = new Edge[3] {
				edges[0],
				edges[1],
				edges[2]
			};

			Edge[] arrayB = new Edge[4] {
				edges[3],
				edges[4],
				edges[2],
				edges[6]
			};

			Edge[] arrayC = new Edge[3] {
				edges[7],
				edges[8],
				edges[2]
			};

			List<Edge[]> arrays = new List<Edge[]> {
				arrayA,
				arrayB,
				arrayC
			};

			List<Node> expectedOutputList = new List<Node>();

			Edge[] expectedOutput = new Edge[8] {
				edges[0],
				edges[1],
				edges[2],
				edges[3],
				edges[4],
				// edges[5], has been replaced by edges[2]
				edges[6],
				edges[7],
				edges[8]
				// edges[9] has been replaced by edges[2]
			};

			RunTests(
				arrays,
				expectedOutput
			);
		}
	}

}
