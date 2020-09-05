using ComLib.Lang.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ComLib.Lang.Types
{
    /// ------------------------------------------------------------------------------------------------
    /// remarks: This file is auto-generated from the FSGrammar specification and should not be modified.
    /// summary: This file contains all the AST for expressions at the system level.
    ///			features like control-flow e..g if, while, for, try, break, continue, return etc.
    /// version: 0.9.8.10
    /// author:  kishore reddy
    /// date:	02/14/13 10:03:37 AM
    /// ------------------------------------------------------------------------------------------------

    /// <summary>Datatype for array</summary>
    public class LArray : LObject
    {
        public LArray(IList val)
        {
            Value = val;
            Type = LTypes.Array;
        }

        public IList Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LArray(Value);
        }

        public override string ToString()
        {
            return $"[{Value[0]}...{Value[^1]}]";
        }
    }

    public class LArrayType : LObjectType
    {
        public LArrayType()
        {
            Name = "array";
            FullName = "sys.array";
            TypeVal = TypeConstants.Array;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for bool</summary>
    public class LBool : LObject
    {
        public LBool(bool val)
        {
            Value = val;
            Type = LTypes.Bool;
        }

        public bool Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LBool(Value);
        }
    }

    public class LBoolType : LObjectType
    {
        public LBoolType()
        {
            Name = "bool";
            FullName = "sys.bool";
            TypeVal = TypeConstants.Bool;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for class</summary>
    public class LClass : LObject
    {
        public LClass(object val)
        {
            Value = val;
            Type = LTypes.Class;
        }

        public object Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LClass(Value);
        }
    }

    public class LClassType : LObjectType
    {
        public LClassType()
        {
            Name = "class";
            FullName = "ext.class";
            TypeVal = TypeConstants.LClass;
            IsSystemType = true;
        }

        public Type DataType;
    }

    /// <summary>Datatype for datetime</summary>
    public class LDate : LObject
    {
        public LDate(DateTime val)
        {
            Value = val;
            Type = LTypes.Date;
        }

        public DateTime Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LDate(Value);
        }
    }

    public class LDateType : LObjectType
    {
        public LDateType()
        {
            Name = "datetime";
            FullName = "sys.datetime";
            TypeVal = TypeConstants.Date;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for dayofweek</summary>
    public class LDayOfWeek : LObject
    {
        public LDayOfWeek(DayOfWeek val)
        {
            Value = val;
            Type = LTypes.DayOfWeek;
        }

        public DayOfWeek Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LDayOfWeek(Value);
        }
    }

    public class LDayOfWeekType : LObjectType
    {
        public LDayOfWeekType()
        {
            Name = "dayofweek";
            FullName = "sys.dayofweek";
            TypeVal = TypeConstants.DayOfWeek;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for function</summary>
    public class LFunction : LObject
    {
        public LFunction(object val)
        {
            Value = val;
            Type = LTypes.Function;
        }

        public object Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LFunction(Value);
        }
    }

    public class LFunctionType : LObjectType
    {
        public LFunctionType()
        {
            Name = "function";
            FullName = "ext.function";
            TypeVal = TypeConstants.Function;
            IsSystemType = true;
        }

        public LType Parent;
    }

    /// <summary>Datatype for map</summary>
    public class LMap : LObject
    {
        public LMap(IDictionary<string, object> val)
        {
            Value = val;
            Type = LTypes.Map;
        }

        public IDictionary<string, object> Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LMap(Value);
        }
    }

    public class LMapType : LObjectType
    {
        public LMapType()
        {
            Name = "map";
            FullName = "sys.map";
            TypeVal = TypeConstants.Map;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for module</summary>
    public class LModule : LObject
    {
        public LModule(object val)
        {
            Value = val;
            Type = LTypes.Module;
        }

        public object Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LModule(Value);
        }
    }

    public class LModuleType : LObjectType
    {
        public LModuleType()
        {
            Name = "module";
            FullName = "ext.module";
            TypeVal = TypeConstants.Module;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for null</summary>
    public class LNull : LObject
    {
        public LNull(object val)
        {
            Value = val;
            Type = LTypes.Null;
        }

        public object Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LNull(Value);
        }
    }

    public class LNullType : LObjectType
    {
        public LNullType()
        {
            Name = "null";
            FullName = "sys.null";
            TypeVal = TypeConstants.Null;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for number</summary>
    public class LNumber : LObject
    {
        public LNumber(double val)
        {
            Value = val;
            Type = LTypes.Number;
        }

        public double Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LNumber(Value);
        }
    }

    public class LNumberType : LObjectType
    {
        public LNumberType()
        {
            Name = "number";
            FullName = "sys.number";
            TypeVal = TypeConstants.Number;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for string</summary>
    public class LString : LObject
    {
        public LString(string val)
        {
            Value = val;
            Type = LTypes.String;
        }

        public string Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LString(Value);
        }
    }

    public class LStringType : LObjectType
    {
        public LStringType()
        {
            Name = "string";
            FullName = "sys.string";
            TypeVal = TypeConstants.String;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for table</summary>
    public class LTable : LObject
    {
        public LTable(IList val)
        {
            Value = val;
            Type = LTypes.Table;
        }

        public IList Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LTable(Value);
        }

        public List<string> Fields;
    }

    public class LTableType : LObjectType
    {
        public LTableType()
        {
            Name = "table";
            FullName = "sys.table";
            TypeVal = TypeConstants.Table;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for time</summary>
    public class LTime : LObject
    {
        public LTime(TimeSpan val)
        {
            Value = val;
            Type = LTypes.Time;
        }

        public TimeSpan Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LTime(Value);
        }
    }

    public class LTimeType : LObjectType
    {
        public LTimeType()
        {
            Name = "time";
            FullName = "sys.time";
            TypeVal = TypeConstants.Time;
            IsSystemType = true;
        }
    }

    /// <summary>Datatype for unit</summary>
    public class LUnit : LObject
    {
        public LUnit(double val)
        {
            Value = val;
            Type = LTypes.Unit;
        }

        public double Value;

        public override object GetValue()
        {
            return Value;
        }

        public override object Clone()
        {
            return new LUnit(Value);
        }

        public double BaseValue { get; set; }

        public string Group { get; set; }

        public string SubGroup { get; set; }
    }

    public class LUnitType : LObjectType
    {
        public LUnitType()
        {
            Name = "unit";
            FullName = "sys.unit";
            TypeVal = TypeConstants.Unit;
            IsSystemType = true;
        }
    }

    public class LTypes
    {
        /// Single instance of the Array type
        public static LObjectType Array = new LArrayType();

        /// Single instance of the Bool type
        public static LObjectType Bool = new LBoolType();

        /// Single instance of the Class type
        public static LObjectType Class = new LClassType();

        /// Single instance of the Date type
        public static LObjectType Date = new LDateType();

        /// Single instance of the DayOfWeek type
        public static LObjectType DayOfWeek = new LDayOfWeekType();

        /// Single instance of the Function type
        public static LObjectType Function = new LFunctionType();

        /// Single instance of the Map type
        public static LObjectType Map = new LMapType();

        /// Single instance of the Module type
        public static LObjectType Module = new LModuleType();

        /// Single instance of the Null type
        public static LObjectType Null = new LNullType();

        /// Single instance of the Number type
        public static LObjectType Number = new LNumberType();

        /// Single instance of the Object type
        public static LObjectType Object = new LObjectType();

        /// Single instance of the String type
        public static LObjectType String = new LStringType();

        /// Single instance of the Table type
        public static LObjectType Table = new LTableType();

        /// Single instance of the Time type
        public static LObjectType Time = new LTimeType();

        /// Single instance of the Unit type
        public static LObjectType Unit = new LUnitType();
    }
}