namespace TrainingDay1
{
    class Strings
    {
        public int vowelCount { get; set; }
        public int consonantCount { get; set; }
        public int wordCount { get; set; }
        public int spaceCount { get; set; }

        public void Count(string input)
        {
            string[] words = input.Split(' ');
            wordCount = words.Length;
            foreach(char a in input)
            {
                if(a== 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u' || a == 'A' || a == 'E' || a == 'I' || a == 'O' ||  a == 'U')
                {
                    vowelCount++;
                }
                else if(a==' ')
                {
                    spaceCount++;
                }
                else
                {
                    consonantCount++;
                }
            }
        }
    }
}
