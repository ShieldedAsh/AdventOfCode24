namespace AdventOfCode;

public class Day1
{
    public static void Main(string[] args)
    {
        string path1 = @"C:\Dev\AdventOfCode\AdventOfCode\txt\Day1.txt";
        string path2 = @"C:\Dev\AdventOfCode\AdventOfCode\txt\Day1pt2.txt";

        List<int> leftSide = new List<int>();
        List<int> rightSide = new List<int>();

        //left side
        try
        {
            foreach(string line in File.ReadLines(path1)){
                if (int.TryParse(line, out int number)){
                    leftSide.Add(number);
                }
                else{
                    System.Console.WriteLine($"Skipping invalid line: {line}");
                }
            }
        }
        catch(Exception ex){
            System.Console.WriteLine($"An error occured: {ex.Message}");
        }

        //right side
        try
        {
            foreach(string line in File.ReadLines(path2)){
                if (int.TryParse(line, out int number)){
                    rightSide.Add(number);
                }
                else{
                    System.Console.WriteLine($"Skipping invalid line: {line}");
                }
            }
        }
        catch(Exception ex){
            System.Console.WriteLine($"An error occured: {ex.Message}");
        }
        
        //sort both lists
        leftSide.Sort();
        rightSide.Sort();

        int sum = 0;
        
        //find distances and sum
        for (int i = 0; i < leftSide.Count; i++)
        {
            int leftVal = leftSide[i];
            int rightVal = rightSide[i];

            if (leftVal > rightVal)
            {
                sum += leftVal - rightVal;
            }
            else{
                sum += rightVal - leftVal;
            }
        }

        //Part 2

        //declare similarity and multiplier values to be iterated over
        int similarity = 0;
        int multiplier = 0;

        //check each left side value and see how many matches there are on the right side
        for (int i = 0; i < leftSide.Count; i++)
        {
            int numToCheck = leftSide[i];
            multiplier = 0;
            for (int j = 0; j < rightSide.Count; j++)
            {
                //increase multiplier for each match
                if (numToCheck == rightSide[j])
                {
                    multiplier++;
                }
            }
            //increase similarity based on how many times the value appears in the list
            similarity += (numToCheck * multiplier);
        }

        //print out solutions
        System.Console.WriteLine(sum);
        System.Console.WriteLine(similarity);
    }
}
