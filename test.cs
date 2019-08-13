using System;
using TagParser;
 
public class Test
{
    
    public static void Main(string[] args)
    {
        TagParser.TagParser g = new TagParser.TagParser();
        g.ParseText("<shake amt=3 type=upanddown>Woahhh <b>Boy!</b></shake> honey <wave amt=2>boy</wave>");
    }
}

/*
mcs test.cs TagParser.cs
*/