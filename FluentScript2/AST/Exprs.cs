﻿using ComLib.Lang.Core;
using System;
using System.Collections.Generic;

namespace ComLib.Lang.AST
{
	/// <summary>1: AST class for ArrayExpr</summary>
	public class ArrayExpr : IndexableExpr
	{
		public ArrayExpr()
		{
			Nodetype = NodeTypes.SysArray;
		}

		public List<Expr> Exprs;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitArray(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitArray(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>2: AST class for AnyOfExpr</summary>
	public class AnyOfExpr : Expr, IParameterExpression
	{
		public AnyOfExpr()
		{
			Nodetype = NodeTypes.SysAnyOf;
		}

		public Expr CompareExpr;

		public List<Expr> ParamListExpressions { get; set; }

		public List<object> ParamList { get; set; }

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitAnyOf(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitAnyOf(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>3: AST class for AssignExpr</summary>
	public class AssignExpr : Expr
	{
		public AssignExpr()
		{
			Nodetype = NodeTypes.SysAssign;
		}

		public Expr VarExp;

		public Expr ValueExp;

		public bool IsDeclaration;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitAssign(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitAssign(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>4: AST class for AssignMultiExpr</summary>
	public class AssignMultiExpr : Expr
	{
		public AssignMultiExpr()
		{
			Nodetype = NodeTypes.SysAssignMulti;
		}

		public List<AssignExpr> Assignments;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitAssignMulti(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitAssignMulti(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>5: AST class for BinaryExpr</summary>
	public class BinaryExpr : Expr
	{
		public BinaryExpr()
		{
			Nodetype = NodeTypes.SysBinary;
		}

		public Expr Left;

		public Expr Right;

		public Operator Op;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitBinary(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitBinary(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>6: AST class for CompareExpr</summary>
	public class CompareExpr : Expr
	{
		public CompareExpr()
		{
			Nodetype = NodeTypes.SysCompare;
		}

		public Expr Left;

		public Expr Right;

		public Operator Op;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitCompare(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitCompare(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>8: AST class for ConstantExpr</summary>
	public class ConstantExpr : ValueExpr
	{
		public new object Value { get; set; }

		public ConstantExpr(object value)
		{
			Nodetype = NodeTypes.SysConstant;
			Value = value;
		}

		public ConstantExpr()
		{
		}

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitConstant(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitConstant(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>9: AST class for DayExpr</summary>
	public class DayExpr : ValueExpr
	{
		public DayExpr()
		{
			Nodetype = NodeTypes.SysDay;
		}

		public new string Name;

		public string Time;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitDay(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitDay(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>10: AST class for DurationExpr</summary>
	public class DurationExpr : ValueExpr
	{
		public DurationExpr()
		{
			Nodetype = NodeTypes.SysDuration;
		}

		public string Duration;

		public string Mode;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitDuration(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitDuration(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>11: AST class for DateExpr</summary>
	public class DateExpr : Expr
	{
		public DateExpr()
		{
			Nodetype = NodeTypes.SysDate;
		}

		public int Month;

		public int Day;

		public int Year;

		public string Time;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitDate(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitDate(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>12: AST class for DateRelativeExpr</summary>
	public class DateRelativeExpr : Expr
	{
		public DateRelativeExpr()
		{
			Nodetype = NodeTypes.SysDateRelative;
		}

		public int Month;

		public int DayOfTheWeek;

		public string RelativeDay;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitDateRelative(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitDateRelative(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>13: AST class for FunctionCallExpr</summary>
	public class FunctionCallExpr : Expr, IParameterExpression
	{
		public FunctionCallExpr()
		{
			Nodetype = NodeTypes.SysFunctionCall;
		}

		public Expr NameExp;

		public List<Expr> ParamListExpressions { get; set; }

		public List<object> ParamList { get; set; }

		public FunctionExpr Function;

		public bool RetainEvaluatedParams;

		public bool IsScopeVariable;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitFunctionCall(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitFunctionCall(this);
		}

		public override string ToQualifiedName()
		{
			return NameExp != null ? NameExp.ToQualifiedName() : "";
		}
	}

	/// <summary>14: AST class for FunctionExpr</summary>
	public class FunctionExpr : BlockExpr
	{
		public FunctionExpr()
		{
			Nodetype = NodeTypes.SysFunction;
		}

		public FunctionMetaData Meta;

		public long ExecutionCount;

		public long ErrorCount;

		public bool HasReturnValue;

		public object ReturnValue;

		public List<object> ArgumentValues;

		public bool ContinueRunning;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitFunction(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitFunction(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>15: AST class for IndexExpr</summary>
	public class IndexExpr : Expr
	{
		public IndexExpr()
		{
			Nodetype = NodeTypes.SysIndex;
		}

		public Expr IndexExp;

		public Expr VarExp;

		public bool IsAssignment;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitIndex(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitIndex(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>16: AST class for InterpolatedExpr</summary>
	public class InterpolatedExpr : Expr
	{
		public InterpolatedExpr()
		{
			Nodetype = NodeTypes.SysInterpolated;
		}

		public List<Expr> Expressions;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitInterpolated(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitInterpolated(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>17: AST class for ListCheckExpr</summary>
	public class ListCheckExpr : Expr
	{
		public ListCheckExpr()
		{
			Nodetype = NodeTypes.SysListCheck;
		}

		public Expr NameExp;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitListCheck(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitListCheck(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>18: AST class for MapExpr</summary>
	public class MapExpr : IndexableExpr
	{
		public MapExpr()
		{
			Nodetype = NodeTypes.SysMap;
		}

		public List<Tuple<string, Expr>> Expressions;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitMap(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitMap(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>19: AST class for MemberAccessExpr</summary>
	public class MemberAccessExpr : Expr
	{
		public MemberAccessExpr()
		{
			Nodetype = NodeTypes.SysMemberAccess;
		}

		public string MemberName;

		public Expr VarExp;

		public bool IsAssignment;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitMemberAccess(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitMemberAccess(this);
		}

		public override string ToQualifiedName()
		{
			return VarExp.ToQualifiedName() + "." + MemberName;
		}
	}

	/// <summary>20: AST class for NamedParameterExpr</summary>
	public class NamedParameterExpr : Expr
	{
		public NamedParameterExpr()
		{
			Nodetype = NodeTypes.SysNamedParameter;
		}

		public string Name;

		public Expr Value;

		public int Pos;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitNamedParameter(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitNamedParameter(this);
		}

		public override string ToQualifiedName()
		{
			return Name;
		}
	}

	/// <summary>21: AST class for NegateExpr</summary>
	public class NegateExpr : VariableExpr
	{
		public NegateExpr()
		{
			Nodetype = NodeTypes.SysNegate;
		}

		public Expr Expression;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitNegate(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitNegate(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>22: AST class for NewExpr</summary>
	public class NewExpr : Expr, IParameterExpression
	{
		public NewExpr()
		{
			Nodetype = NodeTypes.SysNew;
		}

		public string TypeName;

		public List<Expr> ParamListExpressions { get; set; }

		public List<object> ParamList { get; set; }

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitNew(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitNew(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>23: AST class for ParameterExpr</summary>
	public class ParameterExpr : Expr, IParameterExpression
	{
		public ParameterExpr()
		{
			Nodetype = NodeTypes.SysParameter;
		}

		public FunctionMetaData Meta;

		public List<Expr> ParamListExpressions { get; set; }

		public List<object> ParamList { get; set; }

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitParameter(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitParameter(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>24: AST class for RunExpr</summary>
	public class RunExpr : Expr
	{
		public RunExpr()
		{
			Nodetype = NodeTypes.SysRun;
		}

		public string FuncName;

		public string Mode;

		public Expr FuncCallOnAfterExpr;

		public Expr FuncCallExpr;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitRun(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitRun(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>25: AST class for TableExpr</summary>
	public class TableExpr : IndexableExpr
	{
		public TableExpr()
		{
			Nodetype = NodeTypes.SysTable;
		}

		public List<string> Fields;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitTable(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitTable(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>26: AST class for UnaryExpr</summary>
	public class UnaryExpr : VariableExpr
	{
		public UnaryExpr()
		{
			Nodetype = NodeTypes.SysUnary;
		}

		public Operator Op;

		public Expr Expression;

		public double Increment;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitUnary(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitUnary(this);
		}

		public override string ToQualifiedName()
		{
			return string.Empty;
		}
	}

	/// <summary>38: AST class for VariableExpr</summary>
	public class VariableExpr : Expr
	{
		public VariableExpr()
		{
			Nodetype = NodeTypes.SysVariable;
		}

		public string Name;

		public override object DoVisit(IAstVisitor visitor)
		{
			return visitor.VisitVariable(this);
		}

		public override object DoEvaluate(IAstVisitor visitor)
		{
			return visitor.VisitVariable(this);
		}

		public override string ToQualifiedName()
		{
			return Name;
		}
	}
}