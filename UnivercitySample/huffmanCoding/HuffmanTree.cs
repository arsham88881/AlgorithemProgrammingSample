using System.Collections;

namespace algorithemProgrammingSample;

public class HuffmanTree
{
    //my list of charecter and frequency with left and right nodes in min-heap tree
    private List<Node> nodes = new List<Node>(); 
    public Node Root { get; set; } //root node 
    public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

    public void Build(string source)
    {
        for (int i = 0; i < source.Length; i++)
        {
            if (!Frequencies.ContainsKey(source[i]))
            {
                Frequencies.Add(source[i], 0);
            }

            Frequencies[source[i]]++; //increase value when repeat character(key)
        }

        foreach (KeyValuePair<char, int> symbol in Frequencies)
        {
            nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
        }

        while (nodes.Count > 1)
        {
            //sort by ascending my node list
            List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

            if (orderedNodes.Count >= 2)
            {
                // Take(get) first two items
                List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                // Create a parent node by combining the frequencies
                Node parent = new Node()
                {
                    Symbol = '*',
                    Frequency = taken[0].Frequency + taken[1].Frequency,
                    Left = taken[0],
                    Right = taken[1]
                };

                nodes.Remove(taken[0]);
                nodes.Remove(taken[1]);
                nodes.Add(parent);
            }

            this.Root = nodes.FirstOrDefault();

        }

    }

    public BitArray Encode(string source)
    {
        List<bool> encodedSource = new List<bool>();

        for (int i = 0; i < source.Length; i++)
        {
            //list<bool> is complex data type and return with all changes
            List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
            encodedSource.AddRange(encodedSymbol);
        }

        BitArray bits = new BitArray(encodedSource.ToArray());

        return bits;
    }

    public string Decode(BitArray bits)
    {
        Node current = this.Root;
        string decoded = "";

        foreach (bool bit in bits)
        {
            if (bit) //if true go to right
            {
                if (current.Right != null) //mean's right node is exist
                {
                    current = current.Right; //go to deeper right node 
                }
            }
            else //if false go to left 
            {
                if (current.Left != null) //mean's left node is exist
                {
                    current = current.Left; //go to deeper left node 
                }
            }

            if (IsLeaf(current))
            {
                decoded += current.Symbol;
                current = this.Root;
            }
        }

        return decoded;
    }

    public bool IsLeaf(Node node)  //check finished my tree 
    {
        return (node.Left == null && node.Right == null);
    }

}
