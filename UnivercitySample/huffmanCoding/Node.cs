namespace algorithemProgrammingSample;

public class Node
{

    public char Symbol { get; set; }
    public int Frequency { get; set; }
    public Node Right { get; set; }
    public Node Left { get; set; }

    public List<bool> Traverse(char symbol, List<bool> data) //traverse the recursive function
    {
        // Leaf (if latest node in the tree)
        if (Right == null && Left == null)
        {
            if (symbol.Equals(this.Symbol))
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        else
        {
            List<bool> left = null;
            List<bool> right = null;

            if (Left != null) //left node is exist 
            {
                List<bool> leftPath = new List<bool>();
                leftPath.AddRange(data);
                leftPath.Add(false); //for this node

                left = Left.Traverse(symbol, leftPath);
            }

            if (Right != null) //right node is exist 
            {
                List<bool> rightPath = new List<bool>();
                rightPath.AddRange(data);
                rightPath.Add(true); //for this node
                right = Right.Traverse(symbol, rightPath);
            }

            if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }
    }
}
