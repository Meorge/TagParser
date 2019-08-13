using System;
using TagParser;
 
public class Test
{
    
    public static void Main(string[] args)
    {

        TagParser.TagParser g = new TagParser.TagParser();
        g.ParseText("<shake amount=3>BOO!</shake> Ah, <b>hahaha</b>. Did I <wave direction=updown>scare</wave> you? ");
        int[] ba = g.tags[2].ArrayOfIndices;
    }
}

/*
mcs test.cs TagParser.cs
*/