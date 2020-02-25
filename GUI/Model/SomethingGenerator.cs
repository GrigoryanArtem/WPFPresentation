using API.Model.Data;
using NLipsum.Core;
using System;
using System.Linq;

namespace GUI.Model
{
    public static class  SomethingGenerator
    {
        private static Random _random = new Random();

        public static Something Generate()
        {
            LipsumGenerator lipsum = new LipsumGenerator();

            return new Something
            {
                Description = lipsum.GenerateLipsum(2),
                DoubleField = Math.Round(_random.NextDouble(), 2),
                Gender = (Gender)_random.Next(0, 3),
                IntField = _random.Next(0, 100),
                Name = FirstCharToUpper(lipsum.RandomWord()),
                StringField = lipsum.RandomWord()
            };
        }

        private static string FirstCharToUpper(string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };
    }
}
