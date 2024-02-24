using Parser;

string path = $"{Environment.CurrentDirectory.ToString()}\\example\\data.cfg";
Console.WriteLine();
string MyKey = Cfg.GetValue(@path, "name");

Console.WriteLine(MyKey);

// --------------------------------------------
// Rewrite file

Cfg.NewValue(@path, "name", "NewValue");