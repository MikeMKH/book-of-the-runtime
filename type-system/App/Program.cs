using System;

namespace App
{
    public record RecordPerson(string FirstName, string LastName);
    /*
    public class RecordPerson : IEquatable<RecordPerson>
    {
    	protected virtual Type EqualityContract {
    		[System.Runtime.CompilerServices.NullableContext (1)]
    		[CompilerGenerated]
    		get {
    			return typeof(RecordPerson);
    		}
    	}
    
    	public string FirstName {
    		get;
    		set;
    	}
    
    	public string LastName {
    		get;
    		set;
    	}
    
    	public RecordPerson (string FirstName, string LastName)
    	{
    		this.FirstName = FirstName;
    		this.LastName = LastName;
    		base._002Ector ();
    	}
    
    	public override string ToString ()
    	{
    		StringBuilder stringBuilder = new StringBuilder ();
    		stringBuilder.Append ("RecordPerson");
    		stringBuilder.Append (" { ");
    		if (PrintMembers (stringBuilder)) {
    			stringBuilder.Append (" ");
    		}
    		stringBuilder.Append ("}");
    		return stringBuilder.ToString ();
    	}
    
    	protected virtual bool PrintMembers (StringBuilder builder)
    	{
    		builder.Append ("FirstName");
    		builder.Append (" = ");
    		builder.Append ((object?)FirstName);
    		builder.Append (", ");
    		builder.Append ("LastName");
    		builder.Append (" = ");
    		builder.Append ((object?)LastName);
    		return true;
    	}
    
    	[System.Runtime.CompilerServices.NullableContext (2)]
    	public static bool operator != (RecordPerson? r1, RecordPerson? r2)
    	{
    		return !(r1 == r2);
    	}
    
    	[System.Runtime.CompilerServices.NullableContext (2)]
    	public static bool operator == (RecordPerson? r1, RecordPerson? r2)
    	{
    		if ((object)r1 != r2) {
    			return r1?.Equals (r2) ?? false;
    		}
    		return true;
    	}
    
    	public override int GetHashCode ()
    	{
    		return (EqualityComparer<Type>.Default.GetHashCode (EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode (FirstName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode (LastName);
    	}
    
    	public override bool Equals (object? obj)
    	{
    		return Equals (obj as RecordPerson);
    	}
    
    	public virtual bool Equals (RecordPerson? other)
    	{
    		if ((object)other != null && EqualityContract == other!.EqualityContract && EqualityComparer<string>.Default.Equals (FirstName, other!.FirstName)) {
    			return EqualityComparer<string>.Default.Equals (LastName, other!.LastName);
    		}
    		return false;
    	}
    
    	public virtual RecordPerson _003CClone_003E_0024 ()
    	{
    		return new RecordPerson (this);
    	}
    
    	protected RecordPerson (RecordPerson original)
    	{
    		FirstName = original.FirstName;
    		LastName = original.LastName;
    	}
    
    	public void Deconstruct (out string FirstName, out string LastName)
    	{
    		FirstName = this.FirstName;
    		LastName = this.LastName;
    	}
    }
    */
    
    public struct StructPerson
    {
        public StructPerson(string first, string last)
          => (FirstName, LastName) = (first, last);
        public string FirstName { get; }
        public string LastName { get; }
    }
    /*
    public struct StructPerson
    {
    	public string FirstName {
    		get;
    	}
    
    	public string LastName {
    		get;
    	}
    
    	public StructPerson (string first, string last)
    	{
    		FirstName = first;
    		LastName = last;
    	}
    }
    */
    
    public readonly struct ReadOnlyStructPerson
    {
        public ReadOnlyStructPerson(string first, string last)
          => (FirstName, LastName) = (first, last);
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
    /*
    public readonly struct ReadOnlyStructPerson
    {
    	public string FirstName {
    		get;
    		set;
    	}
    
    	public string LastName {
    		get;
    		set;
    	}
    
    	public ReadOnlyStructPerson (string first, string last)
    	{
    		string text2 = FirstName = first;
    		text2 = (LastName = last);
    	}
    }
    */
    
    public class Program
    {
        public static void Main(string[] args)
        {
            RecordPerson x = new ("Mike", "Record");
            StructPerson y = new ("Mike", "Struct");
            ReadOnlyStructPerson z = new ("Mike", "ReadOnly-Struct");
            
            Console.WriteLine($"Hello {x.FirstName} {x.LastName}! [{x}]");
            Console.WriteLine($"Hello {y.FirstName} {y.LastName}! [{y}]");
            Console.WriteLine($"Hello {z.FirstName} {z.LastName}! [{z}]");
        }
    }
    /*
    public class Program
    {
    	public static void Main (string[] args)
    	{
    		RecordPerson recordPerson = new RecordPerson ("Mike", "Record");
    		StructPerson structPerson = new StructPerson ("Mike", "Struct");
    		ReadOnlyStructPerson readOnlyStructPerson = new ReadOnlyStructPerson ("Mike", "ReadOnly-Struct");
    		Console.WriteLine ($"Hello {recordPerson.FirstName} {recordPerson.LastName}! [{recordPerson}]");
    		Console.WriteLine ($"Hello {structPerson.FirstName} {structPerson.LastName}! [{structPerson}]");
    		Console.WriteLine ($"Hello {readOnlyStructPerson.FirstName} {readOnlyStructPerson.LastName}! [{readOnlyStructPerson}]");
    	}
    }    
    */
    /*
    .class public auto ansi beforefieldinit App.Program
    	extends [System.Runtime]System.Object
    {
    	// Methods
    	.method public hidebysig static 
    		void Main (
    			string[] args
    		) cil managed 
    	{
    		// Method begins at RVA 0x2304
    		// Code size 149 (0x95)
    		.maxstack 4
    		.entrypoint
    		.locals init (
    			[0] class App.RecordPerson,
    			[1] valuetype App.StructPerson,
    			[2] valuetype App.ReadOnlyStructPerson
    		)
    
    		IL_0000: ldstr "Mike"
    		IL_0005: ldstr "Record"
    		IL_000a: newobj instance void App.RecordPerson::.ctor(string, string)
    		IL_000f: stloc.00
    		IL_0010: ldloca.s 1
    		IL_0012: ldstr "Mike"
    		IL_0017: ldstr "Struct"
    		IL_001c: call instance void App.StructPerson::.ctor(string, string)
    		IL_0021: ldloca.s 2
    		IL_0023: ldstr "Mike"
    		IL_0028: ldstr "ReadOnly-Struct"
    		IL_002d: call instance void App.ReadOnlyStructPerson::.ctor(string, string)
    		IL_0032: ldstr "Hello {0} {1}! [{2}]"
    		IL_0037: ldloc.00
    		IL_0038: callvirt instance string App.RecordPerson::get_FirstName()
    		IL_003d: ldloc.00
    		IL_003e: callvirt instance string App.RecordPerson::get_LastName()
    		IL_0043: ldloc.00
    		IL_0044: call string [System.Runtime]System.String::Format(string, object, object, object)
    		IL_0049: call void [System.Console]System.Console::WriteLine(string)
    		IL_004e: ldstr "Hello {0} {1}! [{2}]"
    		IL_0053: ldloca.s 1
    		IL_0055: call instance string App.StructPerson::get_FirstName()
    		IL_005a: ldloca.s 1
    		IL_005c: call instance string App.StructPerson::get_LastName()
    		IL_0061: ldloc.11
    		IL_0062: box App.StructPerson
    		IL_0067: call string [System.Runtime]System.String::Format(string, object, object, object)
    		IL_006c: call void [System.Console]System.Console::WriteLine(string)
    		IL_0071: ldstr "Hello {0} {1}! [{2}]"
    		IL_0076: ldloca.s 2
    		IL_0078: call instance string App.ReadOnlyStructPerson::get_FirstName()
    		IL_007d: ldloca.s 2
    		IL_007f: call instance string App.ReadOnlyStructPerson::get_LastName()
    		IL_0084: ldloc.22
    		IL_0085: box App.ReadOnlyStructPerson
    		IL_008a: call string [System.Runtime]System.String::Format(string, object, object, object)
    		IL_008f: call void [System.Console]System.Console::WriteLine(string)
    		IL_0094: ret
    	} // end of method Program::Main
    
    	.method public hidebysig specialname rtspecialname 
    		instance void .ctor () cil managed 
    	{
    		// Method begins at RVA 0x23a5
    		// Code size 7 (0x7)
    		.maxstack 8
    
    		IL_0000: ldarg.00
    		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
    		IL_0006: ret
    	} // end of method Program::.ctor
    
    } // end of class App.Program
    */
}

