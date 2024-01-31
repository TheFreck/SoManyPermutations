namespace SoManyPermutations
{
    public class Permutations
    {
        public static List<string> SinglePermutations(string s)
        {
            var permHash = new HashSet<string>();
            var len = s.Length;
            var inputArray = s.ToCharArray().Select(c => c.ToString()).ToArray();
            var fact = Enumerable.Range(1, len).Aggregate(1, (p, item) => p * item);
            var perms = inputArray.ToList();
            for (var i = 0; i < len - 1; i++)
            {
                perms = Permute(inputArray, perms);
            }
            return perms;
        }

        public static List<string> Permute(string[] inputs, List<string> outputs)
        {
            var permList = new List<string>();
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < inputs.Length; j++)
                {
                    if (outputs[i].Contains(inputs[j])) continue;
                    permList.Add(outputs[i] + inputs[j]);
                }
            }
            permList.Sort();
            return permList.Count > 0 ? permList : outputs;
        }
    }
}
