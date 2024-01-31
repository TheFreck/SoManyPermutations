using Machine.Specifications;

namespace SoManyPermutations.Specs
{
    public class When_Finding_Permutations_Of_One_Or_Two_Symbols
    {
        Establish context = () =>
        {
            inputs = new string[][] 
            {
                new[] { "a" } ,
                new[] { "a","b" },
            };
            expected = new List<string>[]
            {
                new List<string> { "a" },
                new List<string> { "ab", "ba"},
            };
            answers = new List<string>[inputs.Length];
        };

        Because of = () =>
        {
            for(var i= 0; i < inputs.Length; i++)
            {
                answers[i] = Permutations.Permute(inputs[i], new List<string>());

            }
        };

        It Should_Return_Expected = () =>
        {
            for(var i=0; i<answers.Length; i++)
            {
                for(var  j= 0; j < answers[i].Count; j++)
                {
                    var answer = answers[i][j];
                    var expect = expected[i][j];
                    answers[i][j].ShouldEqual(expected[i][j]);
                }
            }
        };

        private static string[][] inputs;
        private static List<string>[] expected;
        private static List<string>[] answers;
    }

    public class When_Finding_Permutations_Of_More_Than_Two_Symbols_With_No_Repeating_Inputs
    {
        Establish context = () =>
        {
            inputs = new string[]
            {
                "a",
                "ab",
                "abc",
                "abcd",
                "abcde",
                "abcdef"
            };
            expected = new List<string>[]
            {
                new List<string> { "a" },
                new List<string> { "ab", "ba"},
                new List<string> { "abc", "acb", "bac", "bca", "cab", "cba"},
                new List<string> { "abcd", "abdc", "acbd", "acdb", "adbc", "adcb", "bacd", "badc", "bcad", "bcda", "bdac", "bdca", "cabd", "cadb", "cbad", "cbda", "cdab", "cdba", "dabc", "dacb", "dbac", "dbca", "dcab", "dcba"},
                new List<string> {},
                new List<string> {}
            };

            for(var a=0; a<5; a++)
            {
                for(var b=0; b<5; b++)
                {
                    for(var c=0; c<5; c++)
                    {
                        for(var d=0; d<5; d++)
                        {
                            for (var e=0; e<5; e++)
                            {
                                if (a == b || a == c || a == d || a == e || 
                                b == c || b == d || b == e || 
                                c == d || c == e || 
                                d == e) continue;
                                expected[4].Add(inputs[4].Substring(a, 1) + inputs[4].Substring(b, 1) + inputs[4].Substring(c, 1) + inputs[4].Substring(d, 1) + inputs[4].Substring(e, 1));
                            }
                        }
                    }
                }
            }
            for(var a=0; a < 6; a++)
            {
                for( var b=0; b < 6; b++)
                {
                    for(var c=0 ; c<6 ; c++)
                    {
                        for(var d= 0 ; d < 6 ; d++)
                        {
                            for(var e= 0 ; e < 6 ; e++)
                            {
                                for(var f= 0 ; f < 6 ; f++)
                                {
                                    if (a == b || a == c || a == d || a == e || a==f || 
                                    b == c || b == d || b == e || b==f ||
                                    c == d || c == e || c==f || 
                                    d == e || d==f ||
                                    e==f) continue;
                                    expected[5].Add(inputs[5].Substring(a, 1) + inputs[5].Substring(b, 1) + inputs[5].Substring(c, 1) + inputs[5].Substring(d, 1) + inputs[5].Substring(e, 1) + inputs[5].Substring(f, 1));
                                }
                            }
                        }
                    }
                }
            }
            answers = new List<string>[inputs.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                answers[i] = Permutations.SinglePermutations(string.Join("",inputs[i]));
            }
        };

        It Should_Return_An_Array_Of_Lists_With_Correct_Number = () =>
        {
            for(var i=0; i < answers.Length; i++)
            {
                answers[i].Count.ShouldEqual(expected[i].Count);
            }
        };
        //It Should_Return_Expected = () => answers.ShouldEqual(expected);
        It Should_Return_Expected_Values = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                for (var j = 0; j < answers[i].Count; j++)
                {
                    var answer = answers[i][j];
                    var expect = expected[i][j];
                    answers[i][j].ShouldEqual(expected[i][j]);
                }
            }
        };

        private static string[] inputs;
        private static List<string>[] expected;
        private static List<string>[] answers;
    }

    public class When_Finding_Permutations_Of_More_Than_Two_Symbols_With_Repeating_Inputs_Allowed
    {
        Establish context = () =>
        {
            inputs = new string[]
            {
                //"aab",
                "aabb"
            };
            expected = new List<string>[]
            {
                //new List<string> { "aab", "aba", "baa" },
                new List<string> { "aabb","abab","abba","baab","baba","bbaa" }
            };
            answers = new List<string>[inputs.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                answers[i] = Permutations.SinglePermutations(string.Join("", inputs[i]));
            }
        };

        It Should_Return_An_Array_Of_Lists_With_Correct_Number = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                answers[i].Count.ShouldEqual(expected[i].Count);
            }
        };
        //It Should_Return_Expected = () => answers.ShouldEqual(expected);
        It Should_Return_Expected_Values = () =>
        {
            for (var i = 0; i < answers.Length; i++)
            {
                for (var j = 0; j < answers[i].Count; j++)
                {
                    var answer = answers[i][j];
                    var expect = expected[i][j];
                    answers[i][j].ShouldEqual(expected[i][j]);
                }
            }
        };

        private static string[] inputs;
        private static List<string>[] expected;
        private static List<string>[] answers;
    }
}