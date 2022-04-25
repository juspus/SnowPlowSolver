// See https://aka.ms/new-console-template for more information
using SnowPlowProblem;
using Dapper;
using Microsoft.Data.Sqlite;

using var d = new Database();

var dbString = new Dapper.DbString();
dbString.Value = "Data Source=lines.db";

using var con = new SqliteConnection(dbString.Value);
var points = con.QueryAsync<Point>("SELECT * from points").Result;

var linesSql = @"SELECT *
from lines
left join Points as StartPoints on StartPoints.Id = StartPointId
left join Points as EndPoints on EndPoints.Id = EndPointId
LIMIT 50";
var lines = con.QueryAsync<Line, Point, Point, Line>(linesSql, ((line, stPoint, endPoint) =>
 {
     line.StartPoint = stPoint;
     line.EndPoint = endPoint;
     return line;
 })).Result;
//var lines2 = d.Lines.ToList();
var dxfD = new netDxf.DxfDocument();
dxfD.Layers.Add(new netDxf.Tables.Layer("Real"));
for (var i = 1; i < lines.Count(); i++)
{
    var s = lines.ElementAt(i-1).EndPoint.ConvertToVector();
    var e = lines.ElementAt(i).StartPoint.ConvertToVector();
    var ee = lines.ElementAt(i).EndPoint.ConvertToVector();

    dxfD.AddEntity(new netDxf.Entities.Line(e, ee) { Layer = dxfD.Layers["Real"] });
    dxfD.AddEntity(new netDxf.Entities.Line(s, e) { Color = netDxf.AciColor.FromTrueColor(i*1000)});
}
dxfD.Save("raw.dxf");


var ga = new SnowPlowSolver.GA(1000, 500, 0.2);
var opPath = ga.OptimizePath(lines);

var dxfOp = new netDxf.DxfDocument();
dxfOp.Layers.Add(new netDxf.Tables.Layer("Real"));
for (var i = 1; i < lines.Count(); i++)
{
    var s = opPath.ElementAt(i - 1).EndPoint.ConvertToVector();
    var e = opPath.ElementAt(i).StartPoint.ConvertToVector();
    var ee = opPath.ElementAt(i).EndPoint.ConvertToVector();
    dxfOp.AddEntity(new netDxf.Entities.Line(e, ee) { Layer = dxfOp.Layers["Real"] });
    dxfOp.AddEntity(new netDxf.Entities.Line(s, e) { Color = netDxf.AciColor.FromTrueColor(i*1000) });
}
dxfOp.Save("op.dxf");


