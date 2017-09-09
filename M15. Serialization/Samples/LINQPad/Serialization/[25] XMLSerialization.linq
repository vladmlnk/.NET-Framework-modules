<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

public class Person
{
	//можно изменить порядок элементов, указывая Order
	[XmlElement (Order = 2)] public string Name;
	[XmlElement (Order = 1)] public int Age;
}

void Main()
{
	Person p = new Person { Name = "Stacey", Age = 30 };
	p.Dump();
	string path = @"C:\Users\MIB\Desktop\";
	XmlSerializer xs = new XmlSerializer (typeof (Person));
	using (Stream s = File.Create (path + "person.xml"))
		xs.Serialize (s, p);
	Person p2;
	using (Stream s = File.OpenRead (path + "person.xml"))
 		p2 = (Person) xs.Deserialize (s);
	p2.Dump();
	//System.Diagnostics.Process.Start (path + "person.xml");
	XDocument.Load(path + "person.xml").Dump();
}