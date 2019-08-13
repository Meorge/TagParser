# TagParser
<b>TagParser</b> is a C# library/script for parsing HTML-style text into a list of indices of the original text.

## Example
Input:
```html
<shake amount=3>BOO!</shake> Ah, <b>hahaha</b>. Did I <wave direction=updown>scare</wave> you? 
```
Output:
```
=========
Raw text: BOO! Ah, hahaha. Did I scare you? 
=========
==== TAGS ====
Tag name: shake
Start index: 0
End index: 3
Properties:
    Key: amount
    Value: 3
===========
Tag name: b
Start index: 9
End index: 14
Properties:
    None
===========
Tag name: wave
Start index: 23
End index: 27
Properties:
    Key: direction
    Value: updown
```

## Usage
First, create a `TagParser` object:
```cs
TagParser parser = new TagParser();
```

Then, feed it a string to parse:
```cs
parser.ParseText("<shake amount=3>BOO!</shake> Ah, <b>hahaha</b>. Did I <wave direction=updown>scare</wave> you?");
```

The `TagParser` object will now hold a list of the `TagObject`s found in the string, which can be accessed via the `.tags` variable.
```cs
Console.Write(parser.tags); // print list of tags
Console.Write(parser.tags[0]); // print the first tag
```

Each `TagObject` has `Name`, `startIndex`, and `endIndex` properties. In addition, the `ArrayOfIndices` property returns an array containing, in order, all of the indices the tag covers.
```cs
TagObject tag = parser.tags[0];
Console.WriteLine(tag.Name); // print the name of the tag
Console.WriteLine(tag.startIndex); // print the index of text at which the tag begun
Console.WriteLine(tag.endIndex); // print the index of text at which the tag ended
Console.WriteLine(tag.ArrayOfIndices); // print all of the indices the tag covers
```

Each `TagObject` also has a `Properties` property, which stores arguments provided in opening tags.
```cs
Console.WriteLine(tag.Properties[0].key); // would print "amount"
Console.WriteLine(tag.Properties[0].value); // would print "3"
```

## Documentation
### `TagParser`
#### `ParseText(string text)`
Call this function with your "input" text to populate its `tags` list.
#### `tags` -> `List<TagObject>`
Returns a list of the tags found when `ParseText()` was called.

<hr/>

### `TagObject`
#### `Name` -> `string`
Returns the name of the tag (the first word inside the opening tag).
#### `Properties` -> `List<TagProperty>`
Returns a list of `TagProperties` representing properties in the opening tag.
#### `contents` -> `string`
Returns the entire content of the inside of the opening tag, including both the name and raw, unparsed properties.
#### `startIndex` -> `int`
Returns the text index at which the tag begins.
#### `endIndex` -> `int`
Returns the text index at which the tag ends.
#### `ArrayOfIndices` -> `int[]`
Returns an array of all of the text indices covered by the tag.
<hr/>

### `TagProperty`
#### `key` -> `string`
Returns the name of the property (such as "speed" or "type").
#### `value` -> `string`
Returns the value the property holds (such as "5" or "large").