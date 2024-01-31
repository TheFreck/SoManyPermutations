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
            foreach(var p in perms)
            {
                permHash.Add(p);
            }
            return permHash.ToList();
        }

        public static List<string> Permute(string[] inputs, List<string> outputs)
        {
            var permList = new List<string>();
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < inputs.Length; j++)
                {
                    //var inputI = inputs[i];
                    //var outputI = outputs[i];
                    //var inputJ = inputs[j];
                    //var outputJ = outputs[j];
                    //var count  = inputs.Count(o => o.Equals(inputI));
                    //var county = outputs[i].Count(o => o.ToString().Equals(inputI));
                    if (outputs[i].Count(o => o.ToString().Equals(inputs[j])) >= inputs.Count(o => o.Equals(inputs[j])))
                    {
                        continue;
                    }
                    //if (outputs[i].Contains(inputs[j])) continue;
                    permList.Add(outputs[i] + inputs[j]);
                }
            }
            permList.Sort();
            return permList.Count > 0 ? permList : outputs;
        }
    }
}
